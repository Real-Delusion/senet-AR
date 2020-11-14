using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging = false;

    public bool SwipeLeft { get => swipeLeft; set => swipeLeft = value; }
    public bool SwipeRight { get => swipeRight; set => swipeRight = value; }
    public Vector2 SwipeDelta { get => swipeDelta; set => swipeDelta = value; }

    // Update is called once per frame
    void OnGUI()
    {
        tap = swipeLeft = swipeRight = false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    tap = true;
                    isDraging = true;
                    startTouch = touch.position;
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    isDraging = false;
                    Reset();
                    break;
                
                case TouchPhase.Canceled:
                    // Report that the touch has canceled
                    isDraging = false;
                    Reset();
                    break;

                default:
                    break;
            }

            // Calulate distance
            swipeDelta = Vector2.zero;

            if (isDraging)
            {
                swipeDelta = Input.GetTouch(0).position - startTouch;
                Debug.Log("DELTA --> " + swipeDelta);
            }

            // Did we cross the deadzone
            if (swipeDelta.magnitude > 20)
            {
                float x = swipeDelta.x;
                float y = swipeDelta.y;

                if(Mathf.Abs(x) > Math.Abs(y))
                {
                    if (x < 0)
                    {
                        swipeLeft = true;
                    }
                    else
                    {
                        swipeRight = true;
                    }
                }

                Reset();
            }
        }

    }

    private void Reset()
    {
        startTouch = SwipeDelta = Vector2.zero;
    }
}
