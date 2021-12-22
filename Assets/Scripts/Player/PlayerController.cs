using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector2 moveDirection;
    private PlayerInteractor mPlayerInteractor;

    void SetFlip()
    {
        if (moveDirection.x < 0)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else if (moveDirection.x > 0)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
    }

    void Start()
    {
        moveDirection = new Vector2(0, 0);
        mPlayerInteractor = GetComponent<PlayerInteractor>();
    }

    void Update()
    {
        moveDirection.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDirection.Normalize();
        SetFlip();

        if (Input.GetKeyDown(KeyCode.E))
        {
            mPlayerInteractor.PerfomSelectedInteraction();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mPlayerInteractor.SelectNextInteraction();
        }
    }

    private void FixedUpdate()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.MovePosition(rigidbody.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
