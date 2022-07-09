using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private int move = 1;
    private bool flag = false;
    private bool flag1 = false;
    private GameObject obj;
    private GameObject obj2;
    private FlushController Flush;
    private HPsystem HP;

    public int difficulty; //��Փx���Ƃɍs���𕪂���

    // Start is called before the first frame update
    void Start()
    {
        Flush = GameObject.Find("RedScreen").GetComponent<FlushController>();
        HP = GameObject.Find("Manager").GetComponent<HPsystem>();

        move = Random.Range(-1, 2);
        if(move == 0)
        {
            move = 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Easy��Herd�̎�
        if (difficulty == 1 || difficulty == 0)
        {
            transform.position += new Vector3(-16.0f * Time.deltaTime, 0, 0);
        }
        //Normal�̎�
        else 
        {
            transform.position += new Vector3(-16.0f * Time.deltaTime, 10.0f * move * Time.deltaTime, 0);
            if(transform.position.y >= 7.0f)
            {
                transform.position = new Vector3(transform.position.x, 7.0f,transform.position.z);
                move *= -1;
            }
            else if(transform.position.y <= 0.5f)
            {
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                move *= -1;
            }
        }

        if (this.transform.position.x <= 1.0 && flag1 == false)
        {
            obj = GameObject.FindWithTag("Player2");
            obj2 = GameObject.FindWithTag("Player");
            flag1 = true;
        }

        if (obj != null && this.gameObject.tag == "Wall" && flag == false)
        {
            if (obj.GetComponent<Player>().Getflashingflag() == false)
            {
                //�����J���Ă���J�x�̏ꍇ
                if (difficulty == 0)
                {
                    //�_��
                    obj.GetComponent<Player>().Setflag();
                    obj.GetComponent<Player>().startten();

                    obj.GetComponent<Player>().SetChangeflagfalse();
                    //��ʂ���u�Ԃ�����
                    Flush.Setflag();
                    HP.Damege(20);
                }
                else
                {

                    //�_��
                    obj.GetComponent<Player>().Setflag();
                    obj.GetComponent<Player>().startten();

                    //��ʂ���u�Ԃ�����
                    Flush.Setflag();
                    HP.Damege(20);
                }
            }

            flag = true;

        }
        else if (obj2 != null && this.gameObject.tag == "Wall2" && flag == false)
        {
            if (obj2.GetComponent<Player>().Getflashingflag() == false)
            {
                //�����J���Ă���J�x�̏ꍇ
                if (difficulty == 0)
                {
                    //�_��
                    obj2.GetComponent<Player>().Setflag();
                    obj2.GetComponent<Player>().startten();

                    obj2.GetComponent<Player>().SetChangeflagfalse();
                    //��ʂ���u�Ԃ�����
                    Flush.Setflag();
                    HP.Damege(20);

                }
                else
                {
                    //�_��
                    obj2.GetComponent<Player>().Setflag();
                    obj2.GetComponent<Player>().startten();

                    //��ʂ���u�Ԃ�����
                    Flush.Setflag();
                    HP.Damege(20);
                }
            }
            flag = true;
        }


        if (transform.position.x < -7)
        {
            Destroy(this.gameObject);
        }
    }      

}
