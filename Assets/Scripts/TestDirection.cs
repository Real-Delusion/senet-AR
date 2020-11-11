using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HandlerDirection;

public class TestDirection : MonoBehaviour
{

    public DirectionHandler directionHandler = new DirectionHandler();
    public Image image;
    public Text message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int direccion = directionHandler.direccionSlide();
        switch (direccion)
        {
            case 1:
                image.color = Color.Lerp(image.color, Color.yellow, 10f * Time.deltaTime);
                message.text = "Derecha";
                break;

            case -1:
                image.color = Color.Lerp(image.color, Color.red, 10f * Time.deltaTime);
                message.text = "Izquierda";
                break;

            default:
                image.color = Color.Lerp(image.color, Color.cyan, 10f * Time.deltaTime);
                message.text = "Parado";
                break;
        }
    }
}
