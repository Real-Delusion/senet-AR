using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HandlerDirection;

public class PanelsManager : MonoBehaviour
{
    // Direction Handle
    //[SerializeField]
    //private DirectionHandler directionHandler = new DirectionHandler();

    [SerializeField]
    private Swipe swipe;

    private int direccion;

    // Lista de los paneles
    [SerializeField][Tooltip ("Array of panels")]
    private PanelScript[] panels;

    // Control Panel
    [SerializeField]
    private int actualPanelId;

    // Start is called before the first frame update
    void Start()
    {
        actualPanelId = 0;
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (swipe.SwipeRight)
        {
            ShowHomeScreen(actualPanelId + 1, 1);
        }
        if (swipe.SwipeLeft)
        {
            ShowHomeScreen(actualPanelId - 1, -1);
        }
        //direccion = directionHandler.direccionSlide();

        //switch (direccion)
        //{
        //    case 1: // derecha
        //        ShowHomeScreen(actualPanelId + 1, direccion);
        //        //StartCoroutine(ShowHomeScreen(actualPanelId + 1, direccion));
        //        //Debug.Log("Derecha");
        //        break;

        //    case -1: // izquierda
        //        ShowHomeScreen(actualPanelId - 1, direccion);
        //        //StartCoroutine(ShowHomeScreen(actualPanelId - 1, direccion));
        //        //Debug.Log("Izquierda");
        //        break;

        //    default:
        //        break;
        //}
    }

    public void ShowHomeScreen(int newPanelId, int direction)
    {
        if (newPanelId >= 0 && newPanelId < panels.Length)
        {
            //Debug.Log("PanelId = " + actualPanelId + " - newPanelId: " + newPanelId);

            panels[actualPanelId].Hide(direction);
            panels[newPanelId].Show();

            actualPanelId = newPanelId;
        }
    }
}
