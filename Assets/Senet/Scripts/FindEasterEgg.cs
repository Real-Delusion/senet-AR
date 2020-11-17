using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FindEasterEgg : MonoBehaviour, IPointerDownHandler {

    // Configure how we listen for clicks (how fast, which button).

    [Tooltip ("Seconds after each click to wait for a follow-up")]
    public float timeLimit = 0.25f;

    [Tooltip ("Number of clicks we expect")]
    public float clicks = 7;

    // Internal state for keeping track of clicks.
    private int clickCount;
    private Coroutine delayedClick;
    private LevelLoader levelLoaderScript;

    void Start () {
        clickCount = 0;
        levelLoaderScript = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    // When clicked
    public void OnPointerDown (PointerEventData eventData) {

        // Count up the clicks
        clickCount++;

        // React accordingly
        if (clickCount == 1) {
            // Start waiting for another click
            delayedClick = StartCoroutine (DelayClick (timeLimit));
        }
        if (clickCount < clicks) {
            // Stop the earlier wait
            StopCoroutine (delayedClick);

            // Restart waiting
            delayedClick = StartCoroutine (DelayClick (timeLimit));
        }
        if (clickCount >= clicks) {
            // Stop waiting
            StopCoroutine (delayedClick);
            delayedClick = null;
            clickCount = 0;
            // Do what should happen after clicks
            loadEasterEgg ();
        }
    }

    // Loads the EasterEgg scene
    private void loadEasterEgg () {
        levelLoaderScript.LoadLevelFade ("EasterEgg");
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