using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MinigameCamera : MonoBehaviour {

    void Start () {
        VuforiaUnity.SetHint (VuforiaUnity.VuforiaHint.HINT_MAX_SIMULTANEOUS_IMAGE_TARGETS, 4);
    }

    // Update is called once per frame
    void Update () { }
}