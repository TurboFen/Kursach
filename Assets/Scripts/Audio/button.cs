using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public AudioClip tap;
    AudioSource AUdio;
    void Start()
    {
        AUdio = GetComponent<AudioSource>();
    }
   public void SoundOn()
    {
        AUdio.PlayOneShot(tap);
    }
}
