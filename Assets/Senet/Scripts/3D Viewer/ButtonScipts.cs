using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScipts : MonoBehaviour
{
    [Tooltip("Place object named 'ConstantPanel' here. \nBaseForRotation > Main Camera > Canvas > ConstantPanel")]
    public GameObject ConstantTextPanel;
    [Tooltip("Place object named 'UserControlPanel' here. \nBaseForRotation > Main Camera > Canvas > UserControlPanel")]
    public GameObject UserControlPanel;
    [Tooltip("Place object named 'DisableTextButton' here. \nBaseForRotation > Main Camera > Canvas > DisableTextButton")]
    public Button DisableTextButton;
    [Tooltip("Place object named 'AutoButton' here. \nBaseForRotation > Main Camera > Canvas > ConstantPanel > AutoButton")]
    public Button AutoModeButton;
    [Tooltip("Value between 0 and 1.\nDetermines how transparent the DisableTextButton is when text is disabled.")]
    public float disabledAlphaValue = .5f;

    private Text buttonText;
    private Color textButtonColor;
    private bool isTextEnabled = true;

    public void DisableTextButtonCall()
    {
        textButtonColor = DisableTextButton.image.color;
        buttonText = DisableTextButton.GetComponentInChildren<Text>();
        if(isTextEnabled)
        {
            isTextEnabled = false;
            ConstantTextPanel.SetActive(false);
            if(!UserInput.isOnAuto)
            {
                UserControlPanel.SetActive(false);
            }
            textButtonColor.a = disabledAlphaValue;
            DisableTextButton.image.color = textButtonColor;
            buttonText.text = "Enable Text".ToString();
        }
        else
        {
            isTextEnabled = true;
            ConstantTextPanel.SetActive(true);
            if (!UserInput.isOnAuto)
            {
                UserControlPanel.SetActive(true);
            }
            textButtonColor.a = 1;
            DisableTextButton.image.color = textButtonColor;
            buttonText.text = "Disable Text".ToString();
        }
    }

    public void AutoModeButtonCall()
    {
        buttonText = AutoModeButton.GetComponentInChildren<Text>();
        if(UserInput.isOnAuto)
        {
            UserInput.isOnAuto = false;
            UserControlPanel.SetActive(true);
            buttonText.text = "Auto Mode: OFF".ToString();
        }
        else
        {
            UserInput.isOnAuto = true;
            UserControlPanel.SetActive(false);
            buttonText.text = "Auto Mode: ON".ToString();
        }
    }
}
