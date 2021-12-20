using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxController : MonoBehaviour
{
    UnityEngine.UI.Text text;
    UnityEngine.UI.Image background;
    public float textPaddingSize = 4f;

    public void Hide()
    {
        text.enabled = false;
        background.enabled = false;
    }

    public void Show()
    {
        text.enabled = true;
        background.enabled = true;
    }

    public bool IsHidden()
    {
        return text.enabled;
    }

    public void SetText(string tooltipText)
    {
        text.text = tooltipText;
        Vector2 messageBoxSize = new Vector2(
            text.preferredWidth + 2 * textPaddingSize, 30);
        GetComponent<RectTransform>().sizeDelta = messageBoxSize;
    }

    void Start()
    {
        text = transform.Find("Text").gameObject.GetComponent<UnityEngine.UI.Text>();
        background = transform.Find("Background").gameObject.GetComponent<UnityEngine.UI.Image>();
        Hide();
    }
}
