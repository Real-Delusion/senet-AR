using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FindEasterEgg : MonoBehaviour, IPointerDownHandler {

    // Configure how we listen for clicks (how fast, which button).

    [Tooltip ("Seconds after each click to wait for a follow-up")]
    public float timeLimit = 0.25f;

    [Tooltip ("Number of clicks we expect")]
    public float clicks = 3;

    // Internal state for keeping track of clicks.
    private int clickCount;
    private Coroutine delayedClick;

    // Auto-configure on Start.
    // I added this to reduce fiddly inspector setup - we'll use an existing
    // EventTrigger component if it's there, or add one & wire it up if not.
    void Start () {
        clickCount = 0;
    }

    public void OnPointerDown (PointerEventData eventData) {
        Debug.Log (this.gameObject.name + " Was Clicked.");

        // Count up the clicks.
        clickCount++;

        // React accordingly.
        if (clickCount == 1) {
            delayedClick = StartCoroutine (DelayClick (timeLimit));
        }
        if (clickCount < clicks) {
            StopCoroutine (delayedClick);
            delayedClick = StartCoroutine (DelayClick (timeLimit));
        }
        if (clickCount >= clicks) {
            StopCoroutine (delayedClick);
            Debug.Log ("loads of clicks");
            delayedClick = null;
            clickCount = 0;
        }
    }

    // This handles firing off the click after a delay.
    // We cancel it if a new click comes in sooner.
    private IEnumerator DelayClick (float delay) {
        yield return new WaitForSeconds (delay);

        // This coroutine didn't get stopped, so no new click came in.
        // Reset.
        clickCount = 0;
        delayedClick = null;
    }
}