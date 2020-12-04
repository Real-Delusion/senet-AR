using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{

    public UnityEngine.Video.VideoPlayer video;
    public GameObject pauseIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (video.isPlaying)
        {
            video.Pause();
            pauseIcon.SetActive(true);
        }
        else
        {
            pauseIcon.SetActive(false);
            video.Play();
        }
    }


}
