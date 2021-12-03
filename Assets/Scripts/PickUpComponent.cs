using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpComponent : GenericInteraction
{
    public string mItemName = "Unnamed item";
    private bool collectAvailable;
    private Collider2D collidedBody;

    // Start is called before the first frame update
    void Start()
    {
        collidedBody = null;
        collectAvailable = false;
    }

    public override string GetInteractionUIString()
    {
        return string.Format("Pick up {0}", mItemName);
    }
    public override void Interact()
    {
        // Collecting item
        ItemSlot item = collidedBody.gameObject.GetComponent<ItemSlot>();
        item.EquipItem(gameObject);
    }

    // Beginning of collision
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If collides with player, then can be picked up
        if (collider.gameObject.CompareTag("Player"))
        {
            collectAvailable = true;
            collidedBody = collider;
        }
    }

    // End of collision
    private void OnTriggerExit2D(Collider2D collider)
    {
        // If was collided with player, cannot be picked up
        if (collider.gameObject.CompareTag("Player"))
        {
            collectAvailable = false;
            collidedBody = null;
        }
    }

    public override bool IsProvideRequired()
    {
        return collectAvailable;
    }

    public override bool IsRevokeRequired()
    {
        return !collectAvailable;
    }
}
