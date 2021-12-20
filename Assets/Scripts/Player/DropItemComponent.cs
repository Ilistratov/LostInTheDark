using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemComponent : GenericInteraction
{
    private ItemSlot item_slot = null;
    public override bool IsActionAvailable() { return item_slot.IsEquipped(); }
    public override void Interact() { item_slot.UnequipItem(); }
    public override string GetUIString()
    {
        return string.Format("Drop {0}", item_slot.GetEquippedItem().GetComponent<PickUpComponent>().mItemName);
    }

    public override void Start()
    {
        base.Start();
        item_slot = gameObject.GetComponent<ItemSlot>();
    }
}
