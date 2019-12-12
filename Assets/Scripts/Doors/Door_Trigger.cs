using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Trigger : MonoBehaviour
{
    public Open_CloseDoor door;
   // public GameObject door_to;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag =="Babyshka")
        {
            door.Open();
          // collision.transform.position = door_to.transform.position;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Babyshka")
        {
            door.Close();
        }
    }
}
