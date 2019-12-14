using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<string> sentences;
    //Mine 
    public string help;
    public Button ButSkip;
    public Button ButtNext;
    public Button ButLearn;
    public DialogueTrigger dt;
    public Text DialogueText; //переменная с самим окошком текст (где будет текст)
    public Animator animator;
    void Start()
    {
        sentences = new Queue<string>();
        if (GetOfGameObj.get() == 3)
        {
            dt.TriggerDialogue();
        }

    }
    public void StartDialogue(Dialogue dialogue) {
       
        sentences.Clear();
        animator.SetBool("IsOpen", true);
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
   //Mine function of skip
   public void Start_help(string sentence)
    {
        animator.SetBool("IsOpen", true);
        DialogueText.text = sentence;
       
    }
    //
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        if (GetOfGameObj.get() == 1)
        {
            animator.SetBool("IsOpen", false);
            ButLearn.gameObject.SetActive(false);
            ButSkip.gameObject.SetActive(false);
            ButtNext.gameObject.SetActive(false);
        }
        else
        {
            animator.SetBool("IsOpen", false);

        }
    }

}
