using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class minigameCamera : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        VuforiaUnity.SetHint (VuforiaUnity.VuforiaHint.HINT_MAX_SIMULTANEOUS_IMAGE_TARGETS, 4);
    }

    // Update is called once per frame
    void Update () {
    }
}