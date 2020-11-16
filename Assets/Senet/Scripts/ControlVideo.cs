using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVideo : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer video;
    public Material material_video;

    // Start is called before the first frame update
    void Start()
    {
        material_video = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(smoothTransition());

        if (video.isPaused)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);

        }
       
    }

    private IEnumerator smoothTransition()
    {

        while (!video.isPrepared)
        {
            yield return null;
        }

        // Making transition from 0 to 1 (transparency)
        // Velocity factor of the transition
        float factor = 1.0f;

        while(material_video.color.a < 1.0f)
        {
            Color aux_color = material_video.color;
            aux_color.a += Time.deltaTime * factor;
            material_video.color = aux_color;
            yield return null;
        }
    }
}
