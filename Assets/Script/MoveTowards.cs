using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTowards : MonoBehaviour
{
    public float speed = 30.0f;
    public float RotateSpeed = 90.0f;
    private GameObject obj;
    private GameObject obj2;

    void FixedUpdate()
    {
        obj = GameObject.FindWithTag("Player");
        obj2 = GameObject.FindWithTag("Player2");

        if (transform.position.x > 0)
        {

            if (obj != null)
            {
                Vector3 lookAtGoal = new Vector3(obj.transform.position.x, transform.position.y, obj.transform.position.z);
                this.transform.LookAt(lookAtGoal);
            }
            else if (obj2 != null)
            {
                Vector3 lookAtGoal = new Vector3(obj2.transform.position.x, transform.position.y, obj2.transform.position.z);
                this.transform.LookAt(lookAtGoal);
            }

            this.transform.Translate(0, 0, speed * Time.deltaTime);

        }
        else
        {
            Destroy(gameObject);
        }
    }


}
