using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall2 : MonoBehaviour
{
    private bool flag = false;
    private bool flag1 = false;
    private GameObject obj;
    private GameObject obj2;
    private FlushController Flush;
    private HPsystem HP;
    private int speed;


    // Start is called before the first frame update
    void Start()
    {
        Flush = GameObject.Find("RedScreen").GetComponent<FlushController>();
        HP = GameObject.Find("Manager").GetComponent<HPsystem>();

        if ( (float)Random.Range(1f, 2f)+0.5f >= 2.0f)
        {
            speed = 1;
        }
        else
        {
            speed = -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position += new Vector3(-14.0f * Time.deltaTime, 0, 14.0f * Time.deltaTime * speed);
 

        if (transform.position.z >= 10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,10);
            speed *= -1;
        }
        if (transform.position.z <= -8)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -8);
            speed *= -1;
        }

        if (this.transform.position.x <= 1.0f && flag1 == false)
        {
            obj = GameObject.FindWithTag("Player2");
            obj2 = GameObject.FindWithTag("Player");
            flag1 = true;
        }

        if (obj != null && this.gameObject.tag == "Wall" && flag == false)
        {
            if (obj.GetComponent<Player>().Getflashingflag() == false)
            {
                obj.GetComponent<Player>().Setflag();
                obj.GetComponent<Player>().startten();
                //âÊñ ÇàÍèuê‘Ç≠Ç∑ÇÈ
                Flush.Setflag();
                HP.Damege(20);
            }
            flag = true;
        }
        else if (obj2 != null && this.gameObject.tag == "Wall2" && flag == false)
        {
            if (obj2.GetComponent<Player>().Getflashingflag() == false)
            {
                obj2.GetComponent<Player>().Setflag();
                obj2.GetComponent<Player>().startten();
                //âÊñ ÇàÍèuê‘Ç≠Ç∑ÇÈ
                Flush.Setflag();
                HP.Damege(20);
            }
            flag = true;
        }


        if (transform.position.x < -7)
        {
            Destroy(this.gameObject);
        }
    }
}
