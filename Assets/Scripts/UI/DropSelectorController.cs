using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSelectorController : MonoBehaviour
{
    UnityEngine.UI.Image selector;
    UnityEngine.UI.Text hintText;

    public Color selectedColor;
    public Color deselectedColor;

    void Start()
    {
        GameObject itemSlotDisplay = GameObject.FindGameObjectWithTag("Item Slot Display");
        selector = itemSlotDisplay.transform.Find("Selector").gameObject.GetComponent<UnityEngine.UI.Image>();
        hintText = itemSlotDisplay.transform.Find("Hint Text").gameObject.GetComponent<UnityEngine.UI.Text>();
    }

    public void OnSelected()
    {
        selector.color = selectedColor;
        hintText.text =
            transform.parent.gameObject.GetComponent<GenericInteraction>().GetUIString();
        hintText.enabled = true;
    }

    public void OnDeselected()
    {
        selector.color = deselectedColor;
        hintText.text = "";
        hintText.enabled = false;
    }
}
