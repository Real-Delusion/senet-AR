using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Preload : MonoBehaviour
{
    // UI
    public GameObject loadingScreen;
    public Slider slider;

    LevelLoader levelLoader;
    private void Start()
    {
        levelLoader = gameObject.GetComponent<LevelLoader>();
        LevelLoaderAsy();
    }
    void Update()
    {
        // Press the space key to start coroutine
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Use a coroutine to load the Scene in the background
        }
    }

    private void LevelLoaderAsy()
    {
        StartCoroutine(LoadYourAsyncScene("Intro Scene"));
    }

    IEnumerator LoadYourAsyncScene(string idScene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(idScene);

        loadingScreen.SetActive(true);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            // UI management
            float progress = Mathf.Clamp01(asyncLoad.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }
}
