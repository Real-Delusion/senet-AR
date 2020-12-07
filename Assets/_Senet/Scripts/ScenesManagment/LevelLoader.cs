using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    // Animotor which controll the scene transition
    public Animator transition;

    public float transitionTime = 1f;

    public void LoadNextlevel () {
        StartCoroutine (LoadLevel (SceneManager.GetActiveScene ().buildIndex + 1));
    }

    // Load level with transition
    public void LoadLevelFade (string level) {
        StartCoroutine (LoadLevel (level));
    }

    // Load level without transition
    public void LoadLevelSimple (string level) {
        SceneManager.LoadScene (level);
    }

    IEnumerator LoadLevel (int levelIndex) {
        transition.SetTrigger ("Start");

        yield return new WaitForSeconds (transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel (string levelIndex) {
        transition.SetTrigger ("Start");

        yield return new WaitForSeconds (transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}