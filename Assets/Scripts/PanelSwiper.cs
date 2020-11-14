using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Vector3 panelLocation;

    [SerializeField]
    private float percentThreshold = 0.2f;

    [SerializeField]
    private float easing = .5f;

    public RectTransform[] panels;

    // Start is called before the first frame update
    void Start()
    {
        SetPosionPanels();
        panelLocation = transform.position;
        Debug.LogError("SCREEN SIZE : " + Screen.width);
    }

    public void OnDrag(PointerEventData eventData)
    {
        float difference = eventData.pressPosition.x - eventData.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int maxRange = Screen.width * (panels.Length - 1);
        Debug.Log("MAXRANGE -------- " + maxRange);
        if (panelLocation.x < maxRange || panelLocation.x > -maxRange)
        {

            float percentage = (eventData.pressPosition.x - eventData.position.x) / Screen.width;

            if (Mathf.Abs(percentage) >= percentThreshold)
            {
                Vector3 newLocation = panelLocation;
                if (percentage > 0)
                {
                    newLocation += new Vector3(-Screen.width, 0, 0);
                } else if (percentage < 0)
                {
                    newLocation += new Vector3(Screen.width, 0, 0);
                }

                StartCoroutine(SmootMove(transform.position, newLocation, easing));
                panelLocation = newLocation;
            }
            else
            {
                StartCoroutine(SmootMove(transform.position, panelLocation, easing));
            }
        }

    }

    IEnumerator SmootMove (Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));

            yield return null;
        }
    }

    private void SetPosionPanels ()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == 0)
            {
                panels[i].DOAnchorPosX(0, 0f);
            }
            else
            {
                Debug.Log(i);
                panels[i].DOAnchorPosX(panels[0].rect.width * i, 0f);
            }
        }
    }

}
