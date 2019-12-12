using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Teleport : MonoBehaviour
{
    public GameObject Door_to;
    public GameObject Player;
    public GameObject Babyshka;
    GrandmaAI gr = null;
    BoyMove bm = null;
    public GameObject pp;
    GameObject currentBab = null;
   //public  Transform forNewPosOfBabyshka = null;
   // public bool is_worked=false; 
    // BoyMove boy;
    public bool to_left = false;
    public bool to_right = false;
    public bool change;
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player" || collider2D.tag == "Babyshka")
            
        {
            if (collider2D.tag == "Babyshka")
            {
                currentBab = collider2D.gameObject;
                gr = currentBab.GetComponent<GrandmaAI>();
            }
            if(collider2D.tag == "Player")
            {
                bm = Player.gameObject.GetComponent<BoyMove>();
            }
            StartCoroutine(Teleport(collider2D.tag));
        }

    }
    IEnumerator Teleport(string col_name)
    {
        yield return new WaitForSeconds(0.2f);
        if (col_name == "Player")
        {
            //Player.transform.position = pp.transform.position;
            if (to_left)
            {
              
                 Player.transform.position = new Vector2(Door_to.transform.position.x - 0.6f, Door_to.transform.position.y - 0.4f);
                bm.FlipDoor(change);
            }
            if (to_right)
            {
                Player.transform.position = new Vector2(Door_to.transform.position.x + 0.6f, Door_to.transform.position.y - 0.4f);
                bm.FlipDoor(change);
            }
        }
        if (col_name == "Babyshka")
        {
            //  Babyshka.transform.position = pp.transform.position;
            if (to_left)
            {
               
                    Babyshka.transform.position = new Vector2(Door_to.transform.position.x - 0.6f, Door_to.transform.position.y - 0.2f);
                    Debug.Log("AAAAAAAAAA");
                    Debug.Log(Babyshka.transform.position);
                    gr.changePos(Babyshka.transform,change);
                    Debug.Log("Babtshka is teleported");
                
            }
            if (to_right)
            {
                Babyshka.transform.position = new Vector2(Door_to.transform.position.x + 0.6f, Door_to.transform.position.y - 0.1f);
                Debug.Log("AAAAAAAAAA");
                Debug.Log(Babyshka.transform.position);
                gr.changePos(Babyshka.transform, change);
                Debug.Log("Babtshka is teleported");
            }
        }
    }
    //Transform to_babyshka( Transform a)
    //{
    //    Debug.Log("Send new place");
    //    Debug.Log(a.position);
    //    return a;
        

    //}
}
