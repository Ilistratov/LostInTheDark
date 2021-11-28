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

    private void Update()
    {
        if (IsEquipped())
        {
            equippedItem.transform.position = transform.position;
        }
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
            removedItem.GetComponent<SpriteRenderer>().enabled = true;
            removedItem.transform.position = itemToEquip.transform.position;
            itemToEquip.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            equippedItem = itemToEquip;
            equippedItem.SetActive(false);
        }
    }

    public void UnequipItem()
    {
        if (IsEquipped())
        {
            GameObject unequippedItem = RemoveEquippedItem();
            unequippedItem.GetComponent<SpriteRenderer>().enabled = true;
            unequippedItem.transform.position = transform.position;
            equippedItem = null;
        }
    }
}
