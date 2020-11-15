using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class PanelScript : MonoBehaviour
{
    // Panel ID
    public int panelID;

    // Tranform de la UI
    RectTransform rectTransform;

    #region Getter
    static PanelScript instance;
    public static PanelScript Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PanelScript>();
            if (instance == null)
                Debug.LogError("PanelScript not found");
            return instance;
        }
    }
    #endregion Getter

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if(panelID == 0)
        {
            rectTransform.DOAnchorPosX(0, 0f);
        }
        else
        {
            rectTransform.DOAnchorPosX(rectTransform.rect.width, 0f);
        }
    }

    public void Show(float delay = 0f)
    {
        rectTransform.DOAnchorPosX(0, 0.3f).SetDelay(delay);
    }

    public void Hide(int direction, float delay = 0f)
    {
        switch (direction)
        {
            case 1: // derecha
                rectTransform.DOAnchorPosX(rectTransform.rect.width * -1, 0.3f).SetDelay(delay);
                Debug.Log("Derecha");
                break;

            case -1: // izquierda
                rectTransform.DOAnchorPosX(rectTransform.rect.width * 1f, 0.3f).SetDelay(delay);
                Debug.Log("Izquierda");
                break;

            default:
                break;
        }
    }
}
