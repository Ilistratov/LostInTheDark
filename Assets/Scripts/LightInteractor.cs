using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightInteractor : MonoBehaviour
{
    public float lightLevel;
    public List<GameObject> collidedLights;

    // Start is called before the first frame update
    void Start()
    {
        lightLevel = 0;
        collidedLights = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        lightLevel = 0;
        if (collidedLights.Count != 0)
        {
            collidedLights.ForEach(CheckForLightRay);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Light2D>() != null)
        {
            collidedLights.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Light2D>() != null)
        {
            collidedLights.Remove(collision.gameObject);
        }
    }

    private void CheckForLightRay(GameObject source)
    {
        Vector2 direction = (source.gameObject.transform.position - transform.position).normalized;
        float distance = (source.gameObject.transform.position - transform.position).magnitude;
        List<RaycastHit2D> allObjectsBetween = new List<RaycastHit2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        int numberOfHits = Physics2D.Raycast(transform.position, direction, filter, allObjectsBetween, distance);
        float localDistance = 1 / (distance * distance);
        lightLevel += 1/(distance * distance);
        for (int i = 0; i < numberOfHits; i++)
        {
            if (allObjectsBetween[i].collider.gameObject.GetComponent<ShadowCaster2D>() != null)
            {
                return;
            }
        }
        //lightLevel += 1 / (distance * distance);
        float rad = source.GetComponent<CircleCollider2D>().radius;
        lightLevel += 1 - (distance * distance) / (rad * rad);
    }
}
