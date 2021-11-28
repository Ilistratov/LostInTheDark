using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private GameObject equippedItem;

    // Start is called before the first frame update
    void Start()
    {
        equippedItem = null;
    }

    // Check if any item is equipped
    public bool IsEquipped()
    {
        return !equippedItem;
    }

    // Remove equipped item and return it (return null if none is equipped)
    public GameObject RemoveEquippedItem()
    {
        GameObject item = equippedItem;
        equippedItem = null;
        return item;
    }

    // Equip the given item, return the equipped one (return null if none is equipped)
    public void EquipItem(GameObject itemToEquip)
    {
        if (equippedItem)
        {
            GameObject removedItem = RemoveEquippedItem();
            equippedItem = itemToEquip;
            removedItem.SetActive(true);
            removedItem.transform.position = itemToEquip.transform.position;
            itemToEquip.SetActive(false);
        }
        else
        {
            equippedItem = itemToEquip;
            equippedItem.SetActive(false);
        }
    }
}
