using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory2 : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[5];
    public Button[] InventoryButtons = new Button[5];
    //Function to add item to inventory
    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
//Find the first open slit in the innventory
for (int index = 0; index < inventory.Length; index++)
        {
            if (inventory [index] == null)
            {
                inventory[index] = item;
                InventoryButtons[index].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                print("Added item to inventory!");
                itemAdded = true;
                //Do something with the object
                item.SendMessage("DoInteraction");
                break;
            }
        }
        //Inventory full
        if (!itemAdded)
        {
            print("Inventory is full and we can't add a new Item");
        }
    }
    public bool FindItem(GameObject item)
    {
        for(int index =0;index < inventory.Length; index++)
        {
            if (inventory[index] == item)
            {
                return true;
            }
        }
        return false;
    }
    public void RemoveItem(GameObject item)
    {
        for (int index = 0; index < inventory.Length; index++)
        {
            if (inventory[index] == item)
            {
                inventory[index] = null;
                Debug.Log("We deleted a used item from inventory");
                InventoryButtons[index].image.overrideSprite = null;
                break;
            }
        }
    }
}
