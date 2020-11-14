using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HandlerDirection
{
    public class DirectionHandler : MonoBehaviour
    {

        // Variables de control de la posición
        private Vector2 startPos;
        private Vector2 endingPos;
        private float diferencia;

        // Variable de la dirección del slide
        private int direccion;

        // Var fija (1 - Derecha) (-1 - Izquierda) (0 - null)
        public readonly int[] sentido = new int[] { -1 , 0 , 1 };

        // Update is called once per frame
        private void detectTouchs()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Handle finger movements based on TouchPhase
                switch (touch.phase)
                {
                    //When a touch has first been detected, change the message and record the starting position
                    case TouchPhase.Began:
                        // Record initial touch position.
                        startPos = touch.position;
                        break;

                    case TouchPhase.Ended:
                        // Report that the touch has ended when it ends
                        endingPos = touch.position;
                        break;
                }
            }

        }

        public int direccionSlide()
        {
            detectTouchs();

            diferencia = startPos.x - endingPos.x;

            if (diferencia > 180 || diferencia < -180)
            {
                if (diferencia > 0f)
                {
                    direccion = sentido[2]; // derecha
                }
                else
                {
                    direccion = sentido[0]; // izquierda
                }
            }
            else
            {
                direccion = sentido[1]; // nada
            }

            return direccion;
        }

        public void testing(Text text)
        {
            Debug.Log("Start pos: ( " + startPos.x + " ) - End pos: ( " + endingPos.x + " )");
            Debug.Log("Diference: "+ diferencia);

            if (direccionSlide() == 1)
            {
                text.text = "Diference : " + diferencia + "derecha ";
            }
            else if (direccionSlide() == -1)
            {
                text.text = "Diference : " + diferencia + "izquierda ";
            }
            else
            {
                text.text = "Diference : " + diferencia;
            }

        }
    }

}
