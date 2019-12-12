using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpTrigger : MonoBehaviour
{
    //public string sentence;
    public void Help_Trigger()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
