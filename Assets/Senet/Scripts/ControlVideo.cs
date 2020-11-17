using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVideo : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer video;
    public Material material_video;
    public GameObject playButton;

    // Start is called before the first frame update
    void Start()
    {
        material_video = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (video.isPlaying)
        {
            playButton.SetActive(false);
        }
        else
        {
            playButton.SetActive(true);

        }

        if (video.isPlaying == true)
        {
            StartCoroutine(smoothTransitionOpen());
        }
        if(video.isPaused)
        {
            StartCoroutine(smoothTransitionClose());
        }

      
    }

    private IEnumerator smoothTransitionOpen()
    {

        while (!video.isPrepared)
        {
            yield return null;
        }

        // Making transition from 0 to 1 (transparency)
        // Velocity factor of the transition
        float factor = 1.0f;

        while (material_video.color.a < 1.0f)
        {
            Color aux_color = material_video.color;
            aux_color.a += Time.deltaTime * factor;
            material_video.color = aux_color;
            yield return null;
        }
    }

    private IEnumerator smoothTransitionClose()
    {

        // Making transition from 0 to 1 (transparency)
        // Velocity factor of the transition
        float factor = 1.0f;

        while (material_video.color.a > 0.0f)
        {
            Color aux_color = material_video.color;
            aux_color.a -= Time.deltaTime * factor;
            material_video.color = aux_color;
            yield return null;
        }
    }
}
