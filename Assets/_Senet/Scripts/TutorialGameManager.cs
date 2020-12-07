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

    GameObject nextButton;
    int stepCount = 0;
    public bool stateCheckbox;

    public void SkipTutorial()
    {
        // Loading game scene
        howToPlay.SetActive(false);
    }

    // When the player choose one of the buttons (yes or no) it saves the state of the checkbox
    // in the player prefs
    public void SaveCheckboxState()
    {
        stateCheckbox = dontShowAgain.isOn;
        PlayerPrefs.SetInt("dontShowAgain", stateCheckbox ? 1 : 0);
        Debug.Log("Changing state of the checkbox: " + stateCheckbox);
    }

    // "Do you know how to play?" question
    public void ShowQuestion()
    {
        howToPlay.SetActive(true);
    }

    // If the user doesn't know how to play the tutorial starts
    public void ShowIntroTutorial()
    {
        howToPlay.SetActive(false);
        introTutorial.SetActive(true);
    }

    // Tutorial with the camera
    public void ShowStepByStep()
    {
        introTutorial.SetActive(false);
        stepByStep.SetActive(true);
    }

    public void ChangeStep()
    {
        if(stepCount < steps.Count - 1)
        {
             // Disable the actual step
             steps[stepCount].SetActive(false);
             stepCount++;
             // Enable the next step
             steps[stepCount].SetActive(true);
        }
        // When is the last step
        else
        {
            // LoadTutorial
            print("Loading tutorial game");
        }
        
    }

    // If the target is on camera it shows the next button
    public void ShowNextButton()
    {
        if (stepCount < 3)
        {
            nextButton = steps[stepCount].transform.GetChild(0).gameObject;
            nextButton.SetActive(true);
        }
    }

    // If the target is not on camera it hides the next button
    public void HideNextButton()
    {
        if (stepCount < 3)
        {
            nextButton = steps[stepCount].transform.GetChild(0).gameObject;
            nextButton.SetActive(false);
        }
        
    }

}
