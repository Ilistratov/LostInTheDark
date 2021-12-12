using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPointerController : MonoBehaviour
{
    SpriteRenderer pointerSprite;
    public Vector2 offset;
    public Color activeColor;
    public Color inactiveColor;

    public void SetActive()
    {
        pointerSprite.color = activeColor;
        pointerSprite.sortingOrder = 2;
    }

    public void SetInactive()
    {
        pointerSprite.color = inactiveColor;
        pointerSprite.sortingOrder = 1;
    }

    public void Hide()
    {
        pointerSprite.enabled = false;
    }

    public void Show()
    {
        pointerSprite.enabled = true;
    }

    void Start()
    {
        pointerSprite = GetComponent<SpriteRenderer>();
        pointerSprite.color = inactiveColor;
        transform.position.Set(offset.x, offset.y, 0);
        SetInactive();
        Hide();
    }
}
