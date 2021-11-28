using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractor : GenericInteraction
{
    public bool is_open = true;
    public DoorInteractor other_side; // the other side of the door
    public Vector3 entry_position_shift; // the shift from the door center to the position player will be removed to after passing throug the door
    private bool interaction_available = false;
    private Collider2D collided_body;

    public override bool IsProvideRequired() { return interaction_available; }
    public override bool IsRevokeRequired() { return !interaction_available; }
    public override void Interact()
    {
        if (is_open)
        {
            collided_body.transform.SetPositionAndRotation(
                other_side.transform.position + other_side.entry_position_shift, collided_body.transform.rotation);
        }
        else
        {
            Debug.Log("Attempted to go through closed door");
        }
    }

    // Collision with player start
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player approached the door");
            interaction_available = true;
            collided_body = collision;
        }
    }

    // Collision with player end
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player left the door");
            interaction_available = false;
            collided_body = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
