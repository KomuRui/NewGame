using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //移動速度
    public float speed = 0.1f;

    //ジャンプ
    private Rigidbody rb;
    public float upForce = 400f; //上方向にかける力
    public int jumpCount = 0;    //ジャンプ回数

    //点滅間隔
    public float interval = 0.3f;
    public bool flag = false;           //点滅一回呼ぶ
    private bool flashingflag = false;  //点滅の間はダメージを受けない
    private bool PlayerChangeflag;      //チェンジできるかどうか

    //フラグ
    //FixedUpdateとUpdateの使い分け
    private bool isJump;         //ジャンプするか
    private bool isLeft;         //左移動するか
    private bool isRight;        //右移動するか

    //プレイヤー変換
    GameObject obj;
    GameObject obj2;

    //エフェクトONOF
    GameObject Efeect;
    GameObject HealEfeect;
    GameObject Bakuobj;

    //HP関係
    HPsystem hp;

    //アイテム関係
    Slot slot;

    // Start is called before the first frame update
    void Start()
    {

        //リジッドボディ
        rb = GetComponent<Rigidbody>();

        //エフェクト
        Efeect = transform.Find("Efeect").gameObject;
        HealEfeect = transform.Find("Heart").gameObject;
        Bakuobj = (GameObject)Resources.Load("NageBomb");

        //プレーや
        obj = (GameObject)Resources.Load("Player2");
        obj2 = (GameObject)Resources.Load("Player");

        //アイテム
        slot = GameObject.Find("item2").GetComponent<Slot>();

        //HP
        hp = GameObject.Find("Manager").GetComponent<HPsystem>();

        //チェンジできるようにしとく
        PlayerChangeflag = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ジャンプ
        if (isJump)
        {
            //二段ジャンプ
            if(jumpCount < 2)
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
                jumpCount++;
            }
            isJump = false;
        }       //左移動
        else if (isLeft && transform.position.z < 9.5)
        {
            this.gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
                //右移動
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
            //もし回復アイテムだったら
            if (slot.GetPlayerImage() == 1)
            {
                HealEfeect.SetActive(true);    　//エフェクト開始
                Invoke("FinishHealEfeect", 1);　 //一秒後にエフェクト終了

                hp.PlusHP(30);

                slot.Setmoto();　　　　　　　　　//使ったアイテム削除
            }

            //もし爆弾アイテムだったら
            else if (slot.GetPlayerImage() == 2)
            {
                Instantiate(Bakuobj, transform.position, Quaternion.Euler(-90, 0, 0));
                slot.Setmoto();
            }
        }

        //点滅するかどうか&点滅の間エフェクトを停止
        startten();

    }


////////////////////////////////////関数////////////////////////////////////////

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

    //点滅動作
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
            StartCoroutine("Blink"); //点滅開始
            flag = false; //点滅一回だけできるようにする

            flashingflag = true; //画面を赤くするか

            //エフェクトがnullなら
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

    //当たり判定
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground") //Groundタグのオブジェクトに触れたとき
        {
            jumpCount = 0;
        }
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Wall2") //Wallタグのオブジェクトに触れたとき
        {

            if (flashingflag == false)
            {
                flag = !flag;

                //画面を一瞬赤くする
                GameObject.Find("RedScreen").GetComponent<FlushController>().Setflag();

                //20ダメージ
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
