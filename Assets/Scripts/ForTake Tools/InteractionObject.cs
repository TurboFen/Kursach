using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;
    public GameObject ItemNeeded;
    public bool isAlreadyUsed = false;
    public bool have_message = false;
    public bool isAlreadyCheck = false;
    public string message;
    public bool hide = false;
    public void DoInteraction()
    {
        //Беру в инвентраь
        gameObject.SetActive(false);
    }
    public void changed()
    {
        UnityFactory.factory.LoadDragonBonesData("Animation/Tool_Anim_ske");
        UnityFactory.factory.LoadDragonBonesData("Animation/Tool_Anim_tex");
        UnityFactory.factory.LoadDragonBonesData("Animation/Gorid1_ske");
        UnityFactory.factory.LoadDragonBonesData("Animation/Gorid1_tex");
        if (!isAlreadyCheck) { this.GetComponent<UnityArmatureComponent>().animation.Play("changeBefore"); }
        else
        {
            this.GetComponent<UnityArmatureComponent>().animation.Play("changeTo");
            this.GetComponent<UnityArmatureComponent>().animation.Play("neGorid");
            print("It should be changed");
        }
    }
    public void say()
    {
        Debug.Log(message);
    }
}
