using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class DogReaction : MonoBehaviour
{
    private BoyMove boy;
    public GameObject boy_gm;
    public UnityArmatureComponent armComp;
    public bool is_angry=false;
    private GrandmaAI grandma;
    public GameObject grandma_gm;
    private bool boy_is_here=false;
    private bool sound = true;
    private float time_go;
    public AudioClip voice;
    AudioSource AUdio;
    void Start()
    {
        AUdio = GetComponent<AudioSource>();
        grandma = grandma_gm.GetComponent<GrandmaAI>();
        boy = boy_gm.GetComponent<BoyMove>();
        time_go = Time.time;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            boy_is_here = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            boy_is_here = false;
        }

    }
    void Update() {
        if (boy_is_here)
        {
            if (boy.is_fast)
            {
                armComp.animation.Play("Back");
              
                is_angry = true;
                if (Time.time >= time_go + 0.5f)
                {
                    if (sound) { AUdio.PlayOneShot(voice);
                        sound = false;

                    }
                    boy.is_game_over = true;
                    grandma.Game_over = true;
                    
                }
                //boy.is_game_over = true;
                //grandma.Game_over = true;
            }
            else
            {
                time_go = Time.time;
               // compare_time = Time.time;
                armComp.animation.Play("To");
                is_angry = false;
                boy.is_game_over = false;
                grandma.Game_over = false;
            }
        }
    }
}
