using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HandlerDirection
{
    public class DirectionHandler : MonoBehaviour
    {

        // Variables de control de la posición
        private Vector2 startPos;
        private Vector2 endingPos;

        // Variable de la dirección del slide 
        private int direccion;

        // Predefinidos (1 - Derecha) (-1 - Izquierda) (0 - No se ha movido)
        private static readonly int[] sentido = new int[] { -1, 0, 1 };

        // Update is called once per frame
        void Update()
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
                        Debug.Log("Start pos: " + startPos);
                        break;

                    case TouchPhase.Ended:
                        // Report that the touch has ended when it ends
                        Debug.Log("Ending");
                        endingPos = touch.position;
                        break;
                }
            }

        }

        public int direccionSlide()
        {
            if (startPos.magnitude > endingPos.magnitude)
            {
                direccion = sentido[2];
            }
            else if (startPos.magnitude < endingPos.magnitude)
            {
                direccion = sentido[0];
            }
            else
            {
                direccion = sentido[1];
            }

            return direccion;
        }
    }

}
