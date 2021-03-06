using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private GameObject equippedItem;
    private UnityEngine.UI.Image slotDisplayItemImage;

    // Start is called before the first frame update
    void Start()
    {
        equippedItem = null;
        slotDisplayItemImage = GameObject.FindGameObjectWithTag("Item Slot Display")
                                          .transform.Find("Item Image")
                                          .gameObject.GetComponent<UnityEngine.UI.Image>();
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
        return equippedItem != null;
    }

    // Remove equipped item and return it (return null if none is equipped)
    public GameObject RemoveEquippedItem()
    {
        GameObject item = equippedItem;
        equippedItem = null;
        slotDisplayItemImage.enabled = false;
        slotDisplayItemImage.sprite = null;
        return item;
    }

    private void ChangeExistence(GameObject item, bool state)
    {
        item.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = state;
        item.GetComponent<BoxCollider2D>().enabled = state;
    }

    // Equip the given item, return the equipped one (return null if none is equipped)
    public void EquipItem(GameObject itemToEquip)
    {
        if (IsEquipped())
        {
            GameObject removedItem = RemoveEquippedItem();
            equippedItem = itemToEquip;
            ChangeExistence(removedItem, true);
            removedItem.transform.position = itemToEquip.transform.position;
            ChangeExistence(itemToEquip, false);
        }
        else
        {
            equippedItem = itemToEquip;
            ChangeExistence(equippedItem, false);
        }
        slotDisplayItemImage.sprite = equippedItem.transform.Find("Sprite")
                                                  .gameObject
                                                  .GetComponent<SpriteRenderer>()
                                                  .sprite;
        slotDisplayItemImage.enabled = true;
    }

    public void UnequipItem()
    {
        if (IsEquipped())
        {
            GameObject unequippedItem = RemoveEquippedItem();
            ChangeExistence(unequippedItem, true);
            unequippedItem.transform.position = transform.position;
            equippedItem = null;
        }
    }
    public GameObject GetEquippedItem()
    {
        return equippedItem;
    }
}
