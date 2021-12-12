using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Set the Player's speed
    private float speed = 1.5f;
    private PlayerInteractor mPlayerInteractor;

    void SetFlip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else if (horizontalInput > 0)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mPlayerInteractor = GetComponent<PlayerInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal and vertical input
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        SetFlip(horizontalInput);

        // Move player to a certain direction
        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        transform.Translate(direction * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            mPlayerInteractor.PerfomSelectedInteraction();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mPlayerInteractor.SelectNextInteraction();
        }
    }
}
