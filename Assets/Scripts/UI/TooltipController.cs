using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipController : MonoBehaviour
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
        Vector2 backgroundSize = new Vector2(
            text.preferredWidth + 2 * textPaddingSize, 30);
        //GetComponent<RectTransform>().sizeDelta = backgroundSize;
        background.rectTransform.sizeDelta = backgroundSize;
        text.rectTransform.sizeDelta = backgroundSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<UnityEngine.UI.Text>();
        background = GetComponentInChildren<UnityEngine.UI.Image>();
        Hide();
    }
}
