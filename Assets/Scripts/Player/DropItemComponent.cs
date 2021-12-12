using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemComponent : GenericInteraction
{
    private ItemSlot item_slot = null;
    public override bool IsProvideRequired() { return item_slot.IsEquipped(); }
    public override bool IsRevokeRequired() { return !item_slot.IsEquipped(); }
    public override void Interact() { item_slot.UnequipItem(); }
    public override string GetInteractionUIString()
    {
        return string.Format("Drop {0}", item_slot.GetEquippedItem().GetComponent<PickUpComponent>().mItemName);
    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        item_slot = gameObject.GetComponent<ItemSlot>();
    }
}
