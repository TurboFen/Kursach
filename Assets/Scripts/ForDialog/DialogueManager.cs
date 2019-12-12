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
    //public bool first_sc;
        //
    public Text DialogueText; //переменная с самим окошком текст (где будет текст)
    public Animator animator; //ну анимация
    void Start()
    {
        sentences = new Queue<string>();
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
        //help = sentence;
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

        //
        DialogueText.text = sentence;

        //
        //StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
    }
    //IEnumerator TypeSentence(string sentence)
    //{
    //    DialogueText.text = "";
    //    foreach(char letter in sentence.ToCharArray())
    //    {
    //        DialogueText.text += letter;
    //        yield return null;
    //    }
    //}
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
        //я добавляю свое
       // Start_help("");
    }

}
