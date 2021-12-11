using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPointerController : MonoBehaviour
{
    SpriteRenderer pointerSprite;
    GameObject objectToFolow;
    public Vector2 offset;

    void UpdatePosition()
    {
        if (objectToFolow)
        {
            transform.position = objectToFolow.transform.position;
            transform.Translate(offset.x, offset.y, 0.0f);
        }
    }

    public void Folow(GameObject newObjectToFolow)
    {
        pointerSprite.enabled = false;
        objectToFolow = newObjectToFolow;
        UpdatePosition();
        pointerSprite.enabled = newObjectToFolow != null;
    }

    void Start()
    {
        pointerSprite = GetComponent<SpriteRenderer>();
        Folow(null);
    }

    void Update()
    {
        UpdatePosition();
    }
}
