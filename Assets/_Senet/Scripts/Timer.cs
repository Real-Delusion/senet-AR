using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    GameObject timer;
    UnityEngine.UI.Text textComponent;
    public float timeRemaining = 10f;

    // Start is called before the first frame update
    void Start()
    {
        timer = this.transform.GetChild(0).gameObject;
        textComponent = timer.GetComponent<UnityEngine.UI.Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining < 0)
        {
            //Game over
        }
        else
        {
            timeRemaining -= Time.deltaTime;
            textComponent.text = "" + Mathf.Round(timeRemaining);
        }
       
       
    }
}
