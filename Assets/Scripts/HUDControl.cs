using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDControl : MonoBehaviour
{

    private GameObject button1;
    private GameObject button2;
    private GameObject button3;
    private bool isClicked = false;


    // Start is called before the first frame update
    void Start()
    {
        button1 = this.transform.GetChild(0).gameObject;
        button2 = this.transform.GetChild(1).gameObject;
        button3 = this.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (isClicked == false)
        {
            OpenButtons();
        }

        else
        {
            CloseButtons();
        }

    }

    private void OpenButtons()
    {

        LeanTween.move(button1, button1.transform.position + new Vector3(0f, -60f, 0f), 0.3f).setEase(LeanTweenType.easeInQuad);
        LeanTween.move(button2, button2.transform.position + new Vector3(0f, -120f, 0f), 0.3f).setEase(LeanTweenType.easeInQuad);
        LeanTween.move(button3, button3.transform.position + new Vector3(0f, -180f, 0f), 0.3f).setEase(LeanTweenType.easeInQuad);

        enableButtons();

    }

    private void CloseButtons()
    {

        LeanTween.move(button1, button1.transform.position + new Vector3(0f, 60f, 0f), 0.3f).setEase(LeanTweenType.easeInQuad);
        LeanTween.move(button2, button2.transform.position + new Vector3(0f, 120f, 0f), 0.3f).setEase(LeanTweenType.easeInQuad);
        LeanTween.move(button3, button3.transform.position + new Vector3(0f, 180f, 0f), 0.3f).setEase(LeanTweenType.easeInQuad);

        LeanTween.delayedCall(0.4f, disableButtons);

    }

    private void enableButtons()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        isClicked = true;

    }

    private void disableButtons()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        isClicked = false;

    }


}
