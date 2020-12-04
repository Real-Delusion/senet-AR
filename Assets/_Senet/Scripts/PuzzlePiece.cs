using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour {

    public Transform correctPos;
    public bool controlPiece;

    // Error margins
    public float marginPosition = 0.2f;
    public float marginRotation = 10f;
    public UnityEvent onLock;

    // Indicates whether the piece is in it's correct placement or not
    private bool _placedPiece = false;

    public bool PlacedPiece {
        get {
            return _placedPiece;
        }
    }

    // Indicates whether the piece is in it's correct position or not
    private bool _positionOk = false;

    public bool PositionOk {
        get {
            return _positionOk;
        }
    }

    // Indicates whether the piece is in it's correct rotation or not
    private bool _rotationOk = false;

    public bool RotationOk {
        get {
            return _rotationOk;
        }
    }

    // Update is called once per frame
    void Update () {

        if (!controlPiece) {
            // Check if the position and the rotation are correct
            bool ok = PositionOk && RotationOk;

            // Compare gameobjects position with it's correct position
            _positionOk = Vector3.Distance (transform.position, correctPos.position) < marginPosition;

            // Compare gameobjects rotation with it's correct position
            _rotationOk = Vector3.Angle (transform.forward, correctPos.forward) < marginRotation;

            // Check if the pieces are connected 
            if (!ok && (PositionOk && RotationOk)) {

                _placedPiece = true;

                // Connect the pieces
                transform.position = correctPos.position;
                transform.rotation = correctPos.rotation;

                Debug.Log (transform.rotation);
                Debug.Log (correctPos.rotation);

                // Put the piece in the other piece
                if (transform.childCount > 0) {
                    transform.GetChild (0).gameObject.transform.parent = correctPos.transform;
                }

                // Start animation
                //onLock.Invoke ();
            }
        }
    }
}