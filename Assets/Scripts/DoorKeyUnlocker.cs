using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyUnlocker : GenericInteraction
{
    public string unlocker_tag = "key"; // Tag of the object that can open this door
    private bool interaction_available = false;
    private DoorInteractor linked_door;
    private Collider2D collided_body;
    public override bool IsProvideRequired() { return interaction_available && !linked_door.is_open; }
    public override bool IsRevokeRequired() { return !interaction_available || linked_door.is_open; }
    public override void Interact()
    {
        if (!linked_door.is_open)
        {
            if (collided_body.GetComponent<ItemSlot>().IsEquipped() && collided_body.GetComponent<ItemSlot>().GetEquippedItem().CompareTag(unlocker_tag))
            {
                linked_door.is_open = true;
            }
            else
            {
                Debug.Log("Couldn't find a key in your Item Slot"); // TODO move this to the message box
            }
        }
        else
        {
            Debug.Log("Attempted to unlock open door");
        }
    }
    public override string GetInteractionUIString()
    {
        return string.Format("Unlock the door");
    }
    // Start is called before the first frame update
    void Start()
    {
        linked_door = gameObject.GetComponent<DoorInteractor>();
    }

    // Collision with player start
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Key approached the door");
            interaction_available = true;
            collided_body = collision;
        }
    }

    // Collision with player end
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Key left the door");
            interaction_available = false;
            collided_body = null;
        }
    }
}
