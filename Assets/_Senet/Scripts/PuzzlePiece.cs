using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour {

    public Transform correctPos;

    // Error margins
    public float marginPosition = 0.2f;
    public float marginRotation = 10f;
    public UnityEvent onLock;

    public Toggle positionCheck;
    public Toggle rotationCheck;

    private bool _positionOk = false;

    public bool PositionOk {
        get {
            return _positionOk;
        }
    }

    private bool _rotationOk = false;

    public bool RotationOk {
        get {
            return _rotationOk;
        }
    }

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        // Check if the position and the rotation are correct
        bool ok = PositionOk && RotationOk;

        // Compare gameobjects position with it's correct position
        _positionOk = Vector3.Distance (transform.position, correctPos.position) < marginPosition;

        // Compare gameobjects rotation with it's correct position
        _rotationOk = Vector3.Angle (transform.forward, correctPos.forward) < marginRotation;

        // Check if the pieces are connected 
        if (!ok && (PositionOk && RotationOk)) {
            Debug.Log ("Connected!");

            // Connect the pieces
            transform.position = correctPos.position;
            transform.rotation = correctPos.rotation;

            // Put the piece in the other piece
            transform.parent = correctPos;

            // Start animation
            onLock.Invoke ();
        }

        positionCheck.isOn = PositionOk;
        rotationCheck.isOn = RotationOk;

    }
}