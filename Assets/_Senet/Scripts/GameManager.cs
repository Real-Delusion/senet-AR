using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // Singleton
    public static GameManager instance = null;

    // Scena de carga
    [SerializeField]
    const string PRELOAD = "Loader";
    // Scene Main
    [SerializeField]
    const string MAIN_MENU = "Main Scene";

    [SerializeField]
    float progress = 0f;

    int win = 0;

    public static float Progress {
        get {
            return instance.progress;
        }
    }

    private void Awake () {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad (gameObject);
        } else {
            DestroyImmediate (gameObject);
        }
    }

    public static void LoadScene (string scene) {
        Debug.Log ("LA SECENA QUE LLEGA --> " + scene);
        SceneManager.LoadScene (PRELOAD, LoadSceneMode.Additive);
        instance.StartCoroutine (instance.Load (scene));
    }

    IEnumerator Load (string scene) {
        progress = 0f;
        yield return null;
        AsyncOperation async = SceneManager.LoadSceneAsync (scene);
        async.allowSceneActivation = false;
        while (!async.isDone) {
            progress = async.progress;
            if (progress >= .9f) {
                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    void OnDisable () {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnEnable () {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            if (SceneManager.GetActiveScene ().name != MAIN_MENU) LoadScene (MAIN_MENU);
        }
    }

    // Each time a scene is loaded (called second)
    void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
        // Get actual scene name
        Scene currentScene = SceneManager.GetActiveScene ();
        Debug.Log ("wonnnnngamemanager" + win);

        if (currentScene.name == "PuzzleMinigame") {
            MinigameManager minigameManager = GameObject.Find ("MinigameManager").GetComponent<MinigameManager> ();
            minigameManager.gamesWon = win;
            Debug.Log (minigameManager.puzzlesAmount);
        }
    }

    public void NextPuzzle () {
        win++;

        // Reload puzzle scene
        LoadScene ("PuzzleMinigame");
    }
}