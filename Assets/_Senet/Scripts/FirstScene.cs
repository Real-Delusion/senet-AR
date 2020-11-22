using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScene : MonoBehaviour
{
    // variable controller
    [SerializeField]
    LevelLoader levelLoader;

    // Check if is first time
    private void Awake()
    {
        // If there is no entry for isFirstTime means it is first time or if there is entry and it is not one means it is first time
        if (!PlayerPrefs.HasKey("isFirstTime") || PlayerPrefs.GetInt("isFirstTime") != 1)
        {
            // Show your prologue here.
            // Now set the value of isFirstTime to be false in the PlayerPrefs.
            PlayerPrefs.SetInt("isFirstTime", 1);
            PlayerPrefs.Save();
        }
        else
        {
            levelLoader.LoadLevelFade("Main Scene");
        }
    }
}
