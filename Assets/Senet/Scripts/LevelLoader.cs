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

    IEnumerator LoadLevel (int levelIndex) {
        transition.SetTrigger ("Start");

        yield return new WaitForSeconds (transitionTime);

        SceneManager.LoadScene (levelIndex);
    }

    // Load level without transition
    public void LoadLevelSimple (string level) {
        SceneManager.LoadScene (level);
    }
}