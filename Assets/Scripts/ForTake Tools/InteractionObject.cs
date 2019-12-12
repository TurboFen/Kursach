using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;  //If true, this object can be store in inventory 
    public GameObject ItemNeeded; //To show is it object to make or not
    public bool isAlreadyUsed = false;
    public bool have_message = false;
    public bool isAlreadyCheck = false;
    public string message;
    public bool hide = false;
  //  public UnityArmatureComponent armComp;
    public void DoInteraction()
    {
        //Picked up and put in inventory
        gameObject.SetActive(false);
    }
    public void changed()
    {
        print("Try to use Animation");
        //armComp.GetComponent<UnityArmatureComponent>();
        UnityFactory.factory.LoadDragonBonesData("Animation/Tool_Anim_ske");
        UnityFactory.factory.LoadDragonBonesData("Animation/Tool_Anim_tex");
        UnityFactory.factory.LoadDragonBonesData("Animation/Gorid1_ske");
        UnityFactory.factory.LoadDragonBonesData("Animation/Gorid1_tex");
        //UnityArmatureComponent arm = GetComponent<UnityArmatureComponent>();
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
