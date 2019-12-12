using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction_on_boy : MonoBehaviour
{
    public Transform[] patrolPointsStolovaya;
    public Transform[] patrolPointsIgrovaya;
    public Transform[] patrolPointsSpalny;
    public GameObject boy;
    float patrol_1, patrol_2, patrol_3, patrol_4;

  void Update()
    {
        if (babayshka_between() && boy_between())
        {
            SendMessage("they_are_here");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Stolovaya")
        {
            patrol_1 = patrolPointsStolovaya[0].position.x;
            patrol_2 = patrolPointsStolovaya[1].position.x;
            patrol_3 = patrolPointsStolovaya[2].position.y;
            patrol_4 = patrolPointsStolovaya[3].position.y;
        }
        if(other.tag == "Igrovaya")
        {
            patrol_1 = patrolPointsIgrovaya[0].position.x;
            patrol_2 = patrolPointsIgrovaya[1].position.x;
            patrol_3 = patrolPointsIgrovaya[2].position.y;
            patrol_4 = patrolPointsIgrovaya[3].position.y;
        }
        if (other.tag == "Spalny")
        {
            Debug.Log("Boy is in the Spalny");
            patrol_1 = patrolPointsSpalny[0].position.x;
            patrol_2 = patrolPointsSpalny[1].position.x;
            patrol_3 = patrolPointsSpalny[2].position.y;
            patrol_4 = patrolPointsSpalny[3].position.y;
        }
    }
        bool boy_between()
    {
        if (boy.activeSelf)
        {
            if (boy.transform.position.x < patrol_2 && boy.transform.position.x > patrol_1 && boy.transform.position.y < patrol_3 && boy.transform.position.y > patrol_4)
            {
                Debug.Log("Boy is true");
                return true;
            }
            else
            {
                Debug.Log("Boy is false");
                return false;
            }
        }
        else { return false; }
    }
    bool babayshka_between()
    {
        if (transform.position.x < patrol_2 && transform.position.x > patrol_1 && transform.position.y<patrol_3 && transform.position.y>patrol_4)
        {
            Debug.Log("Babyshka is true");
            return true;
        }
        else
        {
            return false;
        }
    }



}
