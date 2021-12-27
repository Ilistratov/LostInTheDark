using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorController : MonoBehaviour
{
    SpriteRenderer selectorSprite;
    GameObject hoverText;
    bool needUpdateTextPosition = false;
    public Color selectedColor;
    public Color deselectedColor;

    void Start()
    {
        selectorSprite = transform.Find("Selector Sprite").GetComponent<SpriteRenderer>();
        hoverText = GameObject.FindGameObjectWithTag("Interaction Display");
        OnDeselected();
        OnHide();
    }

    public void OnSelected(string uiString)
    {
        selectorSprite.color = selectedColor;
        var text = hoverText.GetComponent<UnityEngine.UI.Text>();
        text.text = uiString;
        UpdateTextPosition();
        text.enabled = true;
        needUpdateTextPosition = true;
    }

    public void OnDeselected()
    {
        selectorSprite.color = deselectedColor;
        var text = hoverText.GetComponent<UnityEngine.UI.Text>();
        text.text = "";
        text.enabled = false;
        needUpdateTextPosition = false;
    }

    public void OnShow()
    {
        selectorSprite.enabled = true;
    }

    public void OnHide()
    {
        selectorSprite.enabled = false;
    }

    void UpdateTextPosition()
    {
        UnityEngine.UI.Text text = hoverText.GetComponent<UnityEngine.UI.Text>();
        Vector3 screenPosition = RectTransformUtility.WorldToScreenPoint(
            Camera.main, transform.Find("HoverTextPosition").transform.position);
        Vector2 uiPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            text.canvas.transform as RectTransform, screenPosition, Camera.main, out uiPosition);
        text.transform.position = text.canvas.transform.TransformPoint(uiPosition);
    }
    
    void FixedUpdate()
    {
        if (needUpdateTextPosition)
        {
            UpdateTextPosition();
        }
    }
}
