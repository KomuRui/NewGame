using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, 14.0f * Time.deltaTime * speed) ;

        if (transform.position.z > 9.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,9.5f);
            speed *= -1;
        }
        else if(transform.position.z < -7.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -7.5f);
            speed *= -1;
        }
    }
}
