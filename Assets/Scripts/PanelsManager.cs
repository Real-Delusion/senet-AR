using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HandlerDirection;

public class PanelsManager : MonoBehaviour
{
    // Direction Handle
    [SerializeField]
    private DirectionHandler directionHandler = new DirectionHandler();

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

        Debug.Log("Lenght panels: " + panels.Length);
    }

    public void ShowHomeScreen(int newPanelId)
    {
        Debug.Log("LLEAGA ANTES DEL SWITCH");
        if (newPanelId >= 0 && newPanelId < panels.Length)
        {
            Debug.Log("PanelId = " + actualPanelId + " - newPanelId: " + newPanelId);

            panels[actualPanelId].Hide();
            panels[newPanelId].Show();

            actualPanelId = newPanelId;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int direccion = directionHandler.direccionSlide();

        switch (direccion)
        {
            case 1: // derecha
                ShowHomeScreen(actualPanelId + 1);
                Debug.Log("Derecha");
                break;

            case -1: // izquierda
                ShowHomeScreen(actualPanelId - 1);
                Debug.Log("Izquierda");
                break;

            default:
                break;
        }
    }
}
