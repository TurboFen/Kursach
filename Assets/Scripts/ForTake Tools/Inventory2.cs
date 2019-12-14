using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory2 : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[5];
    public Button[] InventoryButtons = new Button[5];
    //Добавление в инвентраь
    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
//Поиск пустой ячейки
for (int index = 0; index < inventory.Length; index++)
        {
            if (inventory [index] == null)
            {
                inventory[index] = item;
                InventoryButtons[index].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                itemAdded = true;
                item.SendMessage("DoInteraction");
                break;
            }
        }
        //Inventory full
        if (!itemAdded)
        {
            print("Инвентарь переполнен");
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
                InventoryButtons[index].image.overrideSprite = null;
                break;
            }
        }
    }
}
