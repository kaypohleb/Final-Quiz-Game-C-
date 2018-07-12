using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
[RequireComponent(typeof(AudioSource))]
//crash video
public class videoPlay : MonoBehaviour
{


    public bool videoEnd = false;
    //Audio
    public MovieTexture movie;
    private AudioSource audio;

    void Start()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        
    }

    void Update()
    {
        if (videoEnd == false)
        {
            movie.Play();
            audio.Play();
            videoEnd = true;
        }
    }

}