using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVideoFullScreen : MonoBehaviour
{
    public GameObject video;
    public GameObject playButton;
    public GameObject closeButton;
    public GameObject mainButton;
    public GameObject pauseIcon;
    public Material material_video;


    private UnityEngine.Video.VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // Getting videoPlayer from video GameObject
        videoPlayer = video.GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // When the video is in the last frame and is not playing
        if (videoPlayer.frame == (long)videoPlayer.frameCount - 1 && videoPlayer.isPlaying == false)
        {
            //Video has finshed playing
            HideVideo();

        }

        if (videoPlayer.isPlaying)
        {
            // Hide playButton when the video is playing
            playButton.SetActive(false);
        }

    }

    public void ShowVideo()
    {
        // Enabling video
        video.SetActive(true);
        // Nice fade transition
        StartCoroutine(smoothTransitionOpen());
        // Showing first frame of the video
        videoPlayer.Play();
        videoPlayer.Pause();
        // Showing playButton
        playButton.SetActive(true);
        // Showing closeButton
        closeButton.SetActive(true);
        // Hiding mainButton
        mainButton.SetActive(false);

    }
    public void HideVideo()
    {
        // Hiding pause icon
        pauseIcon.SetActive(false);
        // Nice fade transition
        StartCoroutine(smoothTransitionClose());
        // Disabling video
        video.SetActive(false);
        // Hiding closeButton
        closeButton.SetActive(false);
        // Showing mainButton
        mainButton.SetActive(true);

    }

    private IEnumerator smoothTransitionOpen()
    {

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        // Making transition from 0 to 1 (transparency)
        // Velocity factor of the transition
        float factor = 1.0f;

        while (material_video.color.a < 1.0f)
        {
            // Getting the color of the material
            Color aux_color = material_video.color;

            // Alpha property of the color 
            aux_color.a += Time.deltaTime * factor;
            material_video.color = aux_color;
            yield return null;
        }
    }

    private IEnumerator smoothTransitionClose()
    {

        // Making transition from 1 to 0 (transparency)
        // Velocity factor of the transition
        float factor = 1.0f;

        while (material_video.color.a > 0.0f)
        {
            // Getting the color of the material
            Color aux_color = material_video.color;

            // Alpha property of the color 
            aux_color.a -= Time.deltaTime * factor;
            material_video.color = aux_color;
            yield return null;
        }
    }

}
