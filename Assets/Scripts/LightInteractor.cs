using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInteractor : MonoBehaviour
{
    public bool lighted;
    private List<GameObject> collidedLights;
    public int numberOfLights = 0;
    // Start is called before the first frame update
    void Start()
    {
        lighted = false;
        collidedLights = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        lighted = false;
        if (collidedLights.Count != 0)
        {
            collidedLights.ForEach(CheckForLightRay);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            collidedLights.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
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
        lighted = true;
        for (int i = 0; i < numberOfHits; i++)
        {
            if (allObjectsBetween[i].collider.gameObject.CompareTag("Wall"))
            {
                lighted = false;
            }
        }
    }
}
