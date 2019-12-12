using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentIntObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory2 inventory;
    public UnityArmatureComponent armComp;
    private float last_time;
    private bool flag = false;
    private string message;
    public DialogueManager speak;
    public bool stop_boy = false;


    IEnumerator Sometime(string msg)
    {
        speak.Start_help(msg);
        yield return new WaitForSeconds(3f);
        speak.EndDialogue();
    }
    void Update()
    {
        if (flag == true)
        {
            if (Time.time <= last_time)
            {
                Debug.Log("I need time to take");
                if (armComp.animation.isPlaying)
                {
                    armComp.animation.Stop("stop");
                    armComp.animation.Stop("walk");
                }
                armComp.animation.Play("makeSMT", 0);
                stop_boy = true;
            }
            else
            {
                // armComp.animation.Stop("makeSMT");
                stop_boy = false;
                armComp.animation.Play("stop");
                if (currentInterObjScript.inventory)
                {
                    inventory.AddItem(currentIntObj);
                }
                else
                {
                    currentInterObjScript.isAlreadyUsed = true;
                    print("The tool is changed");
                    currentInterObjScript.changed();
                    inventory.RemoveItem(currentInterObjScript.ItemNeeded);
                }
                //speak.Start_help("Я взял это!");


                print("I Taake it!");
                flag = false;
            }
        }
        if (Input.GetButtonDown("Interact") && currentIntObj && gameObject.activeSelf)
        {
            if (!currentInterObjScript.hide)
            {

                //Check if this object is to be store in inventory
                if (currentInterObjScript.inventory)//If this obj add to inv
                {
                    if (!flag)
                    {
                        last_time = Time.time + 0.5f;
                        flag = true;
                    }
                }

                // Check is this objeck already used
                if (!currentInterObjScript.isAlreadyUsed && !currentInterObjScript.inventory)
                {
                    // Check to see if we had a needed object to make something
                    //Search our inventory for an needed  item - if found make smt
                    if (inventory.FindItem(currentInterObjScript.ItemNeeded))
                    {
                        if (!flag)
                        {
                            last_time = Time.time + 0.5f;
                            flag = true;
                        }
                        //We found a needed item and use it
                        //currentInterObjScript.isAlreadyUsed = true;
                        //print("The tool is changed");
                        //currentInterObjScript.changed();
                        //inventory.RemoveItem(currentInterObjScript.ItemNeeded);
                    }
                    else
                    {
                        if (currentInterObjScript.have_message)
                        {
                            currentInterObjScript.say();
                            message = "We don't have a special tool to use";
                            StartCoroutine(Sometime(message));
                           // FindObjectOfType<DialogueManager>().Start_help("We don't have a special tool to use");
                            print("We don't have a special tool to use");
                        }

                    }
                }
                else
                {
                    //IIs alredy used
                    if (!currentInterObjScript.inventory)
                    {
                        message = "We have already changed it!";
                        StartCoroutine(Sometime(message));
                        print("We have already changed it!");
                    }
                }
            }
            else
            {
               // isHide = false;
gameObject.SetActive(false);
                Debug.Log("Boy is hide");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "InteractableObj") 
        {
           // speak.Start_help("I can take it or use");
            print("I am near of it");
            currentIntObj = other.gameObject;
            currentInterObjScript = currentIntObj.GetComponent<InteractionObject>();
            if (currentInterObjScript.hide)
            {
                speak.Start_help("I can hide here");
            }
            if (currentInterObjScript.inventory)
            {
                speak.Start_help("I can take it to inventory and use later");
            }
            if(!currentInterObjScript.inventory && !currentInterObjScript.hide)
            {
                speak.Start_help("I can make something with it");
            }
          //  Debug.Log(other.name);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "InteractableObj" )
        {
            
            if (collision.gameObject == currentIntObj)
            {
                
                    currentIntObj = null;
                speak.EndDialogue();
                }
            
        }

    }
}
