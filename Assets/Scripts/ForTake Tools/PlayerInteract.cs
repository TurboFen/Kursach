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
                stop_boy = false;
                armComp.animation.Play("stop");
                if (currentInterObjScript.inventory)
                {
                    inventory.AddItem(currentIntObj);
                }
                else
                {
                    currentInterObjScript.isAlreadyUsed = true;
                    currentInterObjScript.changed();
                    inventory.RemoveItem(currentInterObjScript.ItemNeeded);
                }
                flag = false;
            }
        }
        if (Input.GetButtonDown("Interact") && currentIntObj && gameObject.activeSelf)
        {
            if (!currentInterObjScript.hide)
            {
                if (currentInterObjScript.inventory)
                {
                    if (!flag)
                    {
                        last_time = Time.time + 0.5f;
                        flag = true;
                    }
                }

                if (!currentInterObjScript.isAlreadyUsed && !currentInterObjScript.inventory)
                {
                    if (inventory.FindItem(currentInterObjScript.ItemNeeded))
                    {
                        if (!flag)
                        {
                            last_time = Time.time + 0.5f;
                            flag = true;
                        }
                    }
                    else
                    {
                        if (currentInterObjScript.have_message)
                        {
                            currentInterObjScript.say();
                            message = "У нас нет специального предмета для взаимодействия";
                            StartCoroutine(Sometime(message));
                        }

                    }
                }
                else
                {
                    //IIs alredy used
                    if (!currentInterObjScript.inventory)
                    {
                        message = "Мы уже испортили его!";
                        StartCoroutine(Sometime(message));
                    }
                }
            }
            else
            {
                //Мальчик спрятался
gameObject.SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "InteractableObj") 
        {
            currentIntObj = other.gameObject;
            currentInterObjScript = currentIntObj.GetComponent<InteractionObject>();
            if (currentInterObjScript.hide)
            {
                speak.Start_help("Я могу здесь спрятаться");
            }
            if (currentInterObjScript.inventory)
            {
                speak.Start_help("Я могу взять это и использовать позже");
            }
            if(!currentInterObjScript.inventory && !currentInterObjScript.hide)
            {
                speak.Start_help("Я могу как-то подпортить это");
            }
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
