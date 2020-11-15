using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour
{

    private GameObject button1;
    private GameObject button2;
    private GameObject button3;
    private GameObject button4;

    public GameObject blur;
    public Sprite open;
    public Sprite close;

    private bool isClicked = false;


    // Start is called before the first frame update
    void Start()
    {
        // Getting the buttons from the parent button (this)
        button1 = this.transform.GetChild(0).gameObject;
        button2 = this.transform.GetChild(1).gameObject;
        button3 = this.transform.GetChild(2).gameObject;
        button4 = this.transform.GetChild(3).gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        // LeanTween.isTweening() knows when the animation is running,
        // !LeanTween.isTweening() is preventing to crash the animation
        if (isClicked == false && !LeanTween.isTweening())
        {
            // Change Menu Open sprite to Menu Close
            this.GetComponent<Image>().sprite = close;
            // Nice open fan animation 
            OpenButtons();
            // Enable background blur
            blur.SetActive(true);
        }

        else if(!LeanTween.isTweening())
        {
            // Change Menu Close sprite to Menu Open
            this.GetComponent<Image>().sprite = open;
            // Nice close fan animation 
            CloseButtons();
            // Disable background blur
            blur.SetActive(false);

        }

    }

    private void OpenButtons()
    {

        enableButtons();

        // Scalling the buttons from scale 0.01,0.01,0.01 to 1,1,1 
        // Adding delay in order to make fan effect
        LeanTween.scale(button1.GetComponent<RectTransform>(), button1.GetComponent<RectTransform>().localScale * 100f, 0.2f);
        LeanTween.scale(button2.GetComponent<RectTransform>(), button2.GetComponent<RectTransform>().localScale * 100f, 0.2f).setDelay(0.1f);
        LeanTween.scale(button3.GetComponent<RectTransform>(), button3.GetComponent<RectTransform>().localScale * 100f, 0.2f).setDelay(0.2f); 
        LeanTween.scale(button4.GetComponent<RectTransform>(), button4.GetComponent<RectTransform>().localScale * 100f, 0.2f).setDelay(0.3f); 


    }

    private void CloseButtons()
    {

        // Scalling the buttons from scale 1,1,1 to 0.01,0.01,0.01
        // Adding delay in order to make fan effect
        LeanTween.scale(button4.GetComponent<RectTransform>(), button4.GetComponent<RectTransform>().localScale * 0.01f, 0.2f);
        button4.SetActive(false);

        LeanTween.scale(button3.GetComponent<RectTransform>(), button3.GetComponent<RectTransform>().localScale * 0.01f, 0.2f).setDelay(0.1f);
        LeanTween.scale(button2.GetComponent<RectTransform>(), button2.GetComponent<RectTransform>().localScale * 0.01f, 0.2f).setDelay(0.2f);
        LeanTween.scale(button1.GetComponent<RectTransform>(), button1.GetComponent<RectTransform>().localScale * 0.01f, 0.2f).setDelay(0.3f);

        // Delaying 0.4f disableButtons method in order to let the animation finishes
        LeanTween.delayedCall(0.4f, disableButtons);


    }

    private void enableButtons()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);

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
