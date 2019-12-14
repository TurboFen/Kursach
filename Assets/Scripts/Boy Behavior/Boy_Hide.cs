using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy_Hide : MonoBehaviour
{
    public GameObject Boy;
    public PlayerInteract playerScript;
    void Start()
    {
        playerScript = Boy.GetComponent<PlayerInteract>();
       
    }
    void Update()
    {
        if (!Boy.activeSelf && Input.GetButtonDown("Interact"))
        {
            Boy.SetActive(true);
        }
    }
}
