using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards2 : MonoBehaviour
{
    public float speed = 60.0f;
    public float RotateSpeed = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        transform.Rotate(new Vector3(0.0f, 0.0f, RotateSpeed * Time.deltaTime));
    }
}
