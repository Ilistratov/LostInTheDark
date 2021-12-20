using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityDisplayController : MonoBehaviour
{
    public Color safelColor;
    public Color dangerColor;

    UnityEngine.UI.Text valueText;
    UnityEngine.UI.Image indicatorImage;
    UnityEngine.UI.Text hintText;
    void Start()
    {
        valueText = transform.Find("Value Text").gameObject.GetComponent<UnityEngine.UI.Text>();
        indicatorImage = transform.Find("Indicator Image").gameObject.GetComponent<UnityEngine.UI.Image>();
        hintText = transform.Find("Hint Text").gameObject.GetComponent<UnityEngine.UI.Text>();
    }

    public void SetValue(float value)
    {
        indicatorImage.fillAmount = value;
        valueText.text = ((int)(value * 100)).ToString();
        Color indicatorColor = safelColor * value + dangerColor * (1 - value);
        valueText.color = indicatorColor;
        indicatorImage.color = indicatorColor;
        if (value < 0.3)
		{
            int t = (int)(UnityEngine.Time.realtimeSinceStartup * 2);
            if (t % 2 == 0)
			{
                hintText.color = safelColor;
			}
            else
			{
                hintText.color = dangerColor;
			}
		}
		else
		{
            hintText.color = safelColor;
		}
    }
}
