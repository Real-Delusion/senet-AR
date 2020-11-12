using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVideo : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer video;
    public Material video_material;

    // Start is called before the first frame update
    void Start()
    {
        video_material = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(cambiarColor());
    }

    private IEnumerator cambiarColor()
    {

        while (!video.isPrepared)
        {
            yield return null;
        }
        float factor = 1.0f;
        while(video_material.color.a < 1.0f)
        {
            Color aux_color = video_material.color;
            aux_color.a += Time.deltaTime * factor;
            video_material.color = aux_color;
            yield return null;
        }
    }
}
