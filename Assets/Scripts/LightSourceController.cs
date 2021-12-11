using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSourceController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Light2D light = GetComponent<Light2D>();
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.radius = light.pointLightOuterRadius - 0.5F;
    }
}
