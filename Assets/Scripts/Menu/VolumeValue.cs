using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeValue : MonoBehaviour
{
    public  AudioSource audioSrc;
    private static float musicVolume = 1f;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
        audioSrc.volume = musicVolume;
    }
   
}
