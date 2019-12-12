using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Win : MonoBehaviour
{

    public UnityArmatureComponent armComp;
    void Start()
    {
        armComp.animation.Play("AngryGrandma");
    }


}
