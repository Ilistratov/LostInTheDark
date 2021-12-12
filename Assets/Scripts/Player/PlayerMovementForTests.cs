using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementForTests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(hor, ver);
        transform.Translate(dir * 2 * Time.deltaTime);
    }
}
