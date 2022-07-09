using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWarp : MonoBehaviour
{
    private GameObject CapsuleB;
    private Vector3 trans;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        trans = GameObject.FindWithTag("Warp").transform.position;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "item")
        other.gameObject.transform.position = new Vector3(trans.x- 2.0f,trans.y - 1.0f,trans.z);
    }
}
