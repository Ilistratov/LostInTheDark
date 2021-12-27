using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSourceController : MonoBehaviour
{
    public bool isEnabledOnStart = true;
    void Start()
    {
        Light2D light = GetComponent<Light2D>();
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.radius = light.pointLightOuterRadius;
        if (isEnabledOnStart)
        {
            Enable();
        }
        else
        {
            Disable();
        }
    }

    public void Enable()
    {
        GetComponent<Light2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
    }

    public void Disable()
    {
        GetComponent<Light2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
