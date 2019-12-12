using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Open_CloseDoor : MonoBehaviour
{
    UnityArmatureComponent armComp;
   // Collider2D cl;
    void Start()
    {
        //UnityFactory.factory.LoadDragonBonesData("Animation/DoorStolovaya_ske");
        //UnityFactory.factory.LoadDragonBonesData("Animation/DoorStolovaya_tex");
        UnityFactory.factory.LoadDragonBonesData("Animation/DoorOpenClose_ske");
        UnityFactory.factory.LoadDragonBonesData("Animation/DoorOpenClose_tex");
        UnityArmatureComponent arm = GetComponent<UnityArmatureComponent>();
      //  cl = GetComponent<Collider2D>();
    }

    public void Open()
    {
        // this.GetComponent<UnityArmatureComponent>().animation.Play("DoorStolovayaClose");
        this.GetComponent<UnityArmatureComponent>().animation.Play("DoorClose");
        // cl.enabled = false;

    }
    public void Close()
    {
        // this.GetComponent<UnityArmatureComponent>().animation.Play("DoorStolovayaOpen");
        this.GetComponent<UnityArmatureComponent>().animation.Play("DoorOpen");
        // cl.enabled = true;
    }
}
