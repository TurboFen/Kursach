using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy_Hide : MonoBehaviour
{
    public GameObject Boy;
    public PlayerInteract playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = Boy.GetComponent<PlayerInteract>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!Boy.activeSelf && Input.GetButtonDown("Interact"))
        {
            Debug.Log("He can go out");
            Boy.SetActive(true);
        }
        else
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            Debug.Log("The condition is not true");
        }
    }
}
