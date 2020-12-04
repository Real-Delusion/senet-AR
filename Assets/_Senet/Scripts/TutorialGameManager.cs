using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGameManager : MonoBehaviour
{
    public Toggle dontShowAgain;
    public GameObject howToPlay;
    public GameObject introTutorial;
    public GameObject stepByStep;
    public List<GameObject> steps;
    public GameObject wellDone;
    public GameObject imageTarget;

    GameObject nextButton;
    int stepCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (dontShowAgain)
        {
            // Load Game
        }
        else
        {
            // Load Tutorial
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ShowIntroTutorial()
    {
        howToPlay.SetActive(false);
        introTutorial.SetActive(true);
    }

    public void ShowStepByStep()
    {
        introTutorial.SetActive(false);
        stepByStep.SetActive(true);
    }

    public void ChangeStep()
    {
        if(stepCount < steps.Count - 1)
        {
             steps[stepCount].SetActive(false);
             stepCount++;
             steps[stepCount].SetActive(true);
        }
        else
        {
            // LoadTutorial
            print("Loading tutorial");
        }
        
    }

    public void LoadGame()
    {
        // Loading game scene
    }

    public void ShowNextButton()
    {
        if (stepCount < 3)
        {
            nextButton = steps[stepCount].transform.GetChild(0).gameObject;
            nextButton.SetActive(true);
        }
    }

    public void HideNextButton()
    {
        if (stepCount < 3)
        {
            nextButton = steps[stepCount].transform.GetChild(0).gameObject;
            nextButton.SetActive(false);
        }
        
    }

}
