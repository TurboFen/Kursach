using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Open_CloseDoor : MonoBehaviour
{
    public AudioClip voice;
    AudioSource AUdio;
   public  UnityArmatureComponent armComp;
   // Collider2D cl;
    void Start()
    {
        AUdio = GetComponent<AudioSource>();
        //UnityFactory.factory.LoadDragonBonesData("Animation/DoorOpenClose_ske");
        //UnityFactory.factory.LoadDragonBonesData("Animation/DoorOpenClose_tex");
        //UnityArmatureComponent arm = GetComponent<UnityArmatureComponent>();
    }

    public void Open()
    {
        AUdio.PlayOneShot(voice);
        //this.GetComponent<UnityArmatureComponent>().animation.Play("DoorClose");
        armComp.animation.Play("DoorClose");

    }
    public void Close()
    {
        // this.GetComponent<UnityArmatureComponent>().animation.Play("DoorOpen");
        armComp.animation.Play("DoorOpen");
    }
}
