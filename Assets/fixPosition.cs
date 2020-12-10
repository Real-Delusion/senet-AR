using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
      this.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.transform.localRotation = Quaternion.identity;
    }
}
