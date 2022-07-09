using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�ړ����x
    public float speed = 0.1f;

    //�W�����v
    private Rigidbody rb;
    public float upForce = 400f; //������ɂ������
    public int jumpCount = 0;    //�W�����v��

    //�_�ŊԊu
    public float interval = 0.3f;
    public bool flag = false;           //�_�ň��Ă�
    private bool flashingflag = false;  //�_�ł̊Ԃ̓_���[�W���󂯂Ȃ�
    private bool PlayerChangeflag;      //�`�F���W�ł��邩�ǂ���

    //�t���O
    //FixedUpdate��Update�̎g������
    private bool isJump;         //�W�����v���邩
    private bool isLeft;         //���ړ����邩
    private bool isRight;        //�E�ړ����邩

    //�v���C���[�ϊ�
    GameObject obj;
    GameObject obj2;

    //�G�t�F�N�gONOF
    GameObject Efeect;
    GameObject HealEfeect;
    GameObject Bakuobj;

    //HP�֌W
    HPsystem hp;

    //�A�C�e���֌W
    Slot slot;

    // Start is called before the first frame update
    void Start()
    {

        //���W�b�h�{�f�B
        rb = GetComponent<Rigidbody>();

        //�G�t�F�N�g
        Efeect = transform.Find("Efeect").gameObject;
        HealEfeect = transform.Find("Heart").gameObject;
        Bakuobj = (GameObject)Resources.Load("NageBomb");

        //�v���[��
        obj = (GameObject)Resources.Load("Player2");
        obj2 = (GameObject)Resources.Load("Player");

        //�A�C�e��
        slot = GameObject.Find("item2").GetComponent<Slot>();

        //HP
        hp = GameObject.Find("Manager").GetComponent<HPsystem>();

        //�`�F���W�ł���悤�ɂ��Ƃ�
        PlayerChangeflag = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�W�����v
        if (isJump)
        {
            //��i�W�����v
            if(jumpCount < 2)
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(new Vector3(0, upForce, 0)); //��Ɍ������ė͂�������
                jumpCount++;
            }
            isJump = false;
        }       //���ړ�
        else if (isLeft && transform.position.z < 9.5)
        {
            this.gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
                //�E�ړ�
        else if(isRight && transform.position.z > -7.5)
        {
            this.gameObject.transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        }


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }

        if(Input.GetKey(KeyCode.A))
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerChangeflag)
            {
                PlayerChange();
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            //�����񕜃A�C�e����������
            if (slot.GetPlayerImage() == 1)
            {
                HealEfeect.SetActive(true);    �@//�G�t�F�N�g�J�n
                Invoke("FinishHealEfeect", 1);�@ //��b��ɃG�t�F�N�g�I��

                hp.PlusHP(30);

                slot.Setmoto();�@�@�@�@�@�@�@�@�@//�g�����A�C�e���폜
            }

            //�������e�A�C�e����������
            else if (slot.GetPlayerImage() == 2)
            {
                Instantiate(Bakuobj, transform.position, Quaternion.Euler(-90, 0, 0));
                slot.Setmoto();
            }
        }

        //�_�ł��邩�ǂ���&�_�ł̊ԃG�t�F�N�g���~
        startten();

    }


////////////////////////////////////�֐�////////////////////////////////////////

    public void PlayerChange()
    {
        if (this.gameObject.tag == "Player")
        {
            Instantiate(obj, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else
        {
            Instantiate(obj2, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public bool Getflashingflag()
    {
        return flashingflag;
    }

    public void FinishHealEfeect()
    {
        HealEfeect.SetActive(false);
    }

    public void SetChangeflagfalse()
    {
        PlayerChangeflag = false;
        Invoke("SetChangeflagTrue", 3);
    }

    private void SetChangeflagTrue()
    {
        PlayerChangeflag = true; 
    }

    public void Setflag()
    {
        flag = true;
    }

    //�_�œ���
    IEnumerator Blink()
    {
        while (true)
        {
            var renderComponent = GetComponent<Renderer>();
            renderComponent.enabled = !renderComponent.enabled;
            yield return new WaitForSeconds(interval);
        }
    }

    public void startten()
    {
        if (flag == true)
        {
            StartCoroutine("Blink"); //�_�ŊJ�n
            flag = false; //�_�ň�񂾂��ł���悤�ɂ���

            flashingflag = true; //��ʂ�Ԃ����邩

            //�G�t�F�N�g��null�Ȃ�
            if (Efeect != null)
            {
                Efeect = transform.Find("Efeect").gameObject;
                Efeect.SetActive(false);
            }

            Invoke("Hoge", 3);
        }

    }

    public void Hoge()
    {
        StopCoroutine("Blink");
        var renderComponent = GetComponent<Renderer>();
        if (renderComponent.enabled == false)
        {
            renderComponent.enabled = !renderComponent.enabled;
        }
        flashingflag = false;
        Efeect.SetActive(true);
    }

    //�����蔻��
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground") //Ground�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        {
            jumpCount = 0;
        }
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Wall2") //Wall�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        {

            if (flashingflag == false)
            {
                flag = !flag;

                //��ʂ���u�Ԃ�����
                GameObject.Find("RedScreen").GetComponent<FlushController>().Setflag();

                //20�_���[�W
                hp.Damege(20);


                if (other.gameObject.name != "SpikeBall(Clone)" && other.gameObject.name != "SpikeBall2(Clone)" && other.gameObject.name != "Wall2(Clone)" && other.gameObject.name != "RedWall2(Clone)")
                {
                    if (other.gameObject.GetComponent<Wall>().difficulty == 0)
                    {
                        SetChangeflagfalse();
                    }
                }

            }

        }
        if(other.gameObject.tag == "heal" || other.gameObject.tag == "Bomb")
        {
            itemBox.instance.Setitem(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    
}
