using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;
    float x;
    float y;

    void Start () {
        xAngle = this.transform.localEulerAngles.y;
        yAngle = this.transform.localEulerAngles.x;
        this.transform.rotation = Quaternion.Euler (yAngle, xAngle, 0);
        Debug.Log(this.transform.localEulerAngles);
    }

    void Update () {
        // arriba arriba dcha dhca
        /*
        if (Input.touchCount > 0) {
            if (Input.GetTouch (0).phase == TouchPhase.Began) {
                FirstPoint = Input.GetTouch (0).position;
                xAngleTemp = xAngle;
                yAngleTemp = yAngle;
            }
            if (Input.GetTouch (0).phase == TouchPhase.Moved) {
                SecondPoint = Input.GetTouch (0).position;
                xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                this.transform.rotation = Quaternion.Euler (-yAngle, xAngle, 0.0f);
            }
        }*/

        // Bien pero tiene fallo al principio de 180grados
        /*
        if (Input.touchCount > 0) {
            if (Input.GetTouch (0).phase == TouchPhase.Began) {
                FirstPoint = Input.GetTouch (0).position;
                xAngleTemp = xAngle;
                yAngleTemp = yAngle;
            }
            if (Input.GetTouch (0).phase == TouchPhase.Moved) {
                SecondPoint = Input.GetTouch (0).position;
                xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                this.transform.rotation = Quaternion.Euler (yAngle, -xAngle, 0.0f);
            }
        }*/
        if (Input.touchCount > 0) {
            if (Input.GetTouch (0).phase == TouchPhase.Began) {
                FirstPoint = Input.GetTouch (0).position;
                xAngleTemp = xAngle;
                yAngleTemp = yAngle;
            }
            if (Input.GetTouch (0).phase == TouchPhase.Moved) {
                SecondPoint = Input.GetTouch (0).position;
                xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                if (yAngle >= -5 && yAngle <= 19) {
                    y = yAngle;
                }
                if (xAngle <= 286 && xAngle >= 254) {
                    x = xAngle;
                }
                this.transform.rotation = Quaternion.Euler (-y, x, 0.0f);
                Debug.Log("x: " + xAngle + " y: " + yAngle);
            }
        }

    }
}