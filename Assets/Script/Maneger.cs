using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maneger : MonoBehaviour
{
    ///////////////////////ステージ///////////////////////////
    //横バー
    GameObject obj;
    GameObject Redobj;
    GameObject Normalobj;
    GameObject NormalRedobj;
    GameObject Herdobj;
    GameObject HerdRedobj;

    //縦バー
    GameObject obj2;
    GameObject Redobj2;

    //後ろの飛んでくる物体
    GameObject MainBackWall;
    GameObject MainBackWall2;

    //ワープステージ
    GameObject Warp;
    GameObject RedWarp;
    GameObject SpikeBall;
    GameObject SpikeBall2;

    //カベ
    GameObject Ana;
    GameObject Ana2;
    GameObject Ana3;
    GameObject AnaRed;
    GameObject AnaRed2;
    GameObject AnaRed3;

    //難易度区別
    public int difficulty = 1;
    private float timer;

    ///////////////////////アイテム//////////////////////////////
    //HP管理
    private HPsystem HP;
    GameObject HPitem;
    //爆弾
    GameObject Bombitem;

    void Start()
    {
        timer = 0.0f;

        ///////////////////////横バー////////////////////////////
        obj = (GameObject)Resources.Load("Wall");
        Redobj = (GameObject)Resources.Load("RedWall");
        Normalobj = (GameObject)Resources.Load("NormalWall");
        NormalRedobj = (GameObject)Resources.Load("NormalRedWall");
        Herdobj = (GameObject)Resources.Load("HerdWall");
        HerdRedobj = (GameObject)Resources.Load("HerdRedWall");

        ///////////////////////縦バー////////////////////////////
        obj2 = (GameObject)Resources.Load("Wall2");
        Redobj2 = (GameObject)Resources.Load("RedWall2");

        ////////////////後ろの飛んでくる物体/////////////////////
        MainBackWall = (GameObject)Resources.Load("MainBackWall");
        MainBackWall2 = (GameObject)Resources.Load("MainBackWall2");
        Invoke("BackWall", 0.25f);

        ///////////////////////ワープ////////////////////////////
        Warp = (GameObject)Resources.Load("Warp");
        RedWarp = (GameObject)Resources.Load("RedWarp");
        SpikeBall = (GameObject)Resources.Load("SpikeBall");
        SpikeBall2 = (GameObject)Resources.Load("SpikeBall2");

        ///////////////////////カベ/////////////////////////////
        Ana =    (GameObject)Resources.Load("Ana");
        Ana2 =   (GameObject)Resources.Load("Ana2");
        Ana3 =   (GameObject)Resources.Load("Ana3");
        AnaRed = (GameObject)Resources.Load("AnaRed");
        AnaRed2 = (GameObject)Resources.Load("AnaRed2");
        AnaRed3 = (GameObject)Resources.Load("AnaRed3");

        ///////////////////////アイテム/////////////////////////
        HP = GameObject.Find("Manager").GetComponent<HPsystem>();
        HPitem = (GameObject)Resources.Load("HPobject");
        Bombitem = (GameObject)Resources.Load("Bomb");
        Invoke("InstantiateHPitem", 10f);
        Invoke("InstantiateBombitem", 6f);

        //難易度ごとに変える
        if (difficulty == 1)
        {
            Invoke("stage", 3);
        }
        else if(difficulty == 2)
        {
            Invoke("Normalstage", 3);
        }
        else if(difficulty == 3)
        {
            Invoke("Herdstage2", 3);
        }

        
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    ////////////////////////////アイテム///////////////////////////////////
    
    //HPitem
    private void InstantiateHPitem()
    {
        if (HP.CheckHP() <= 60)
        {
            float rndz = Random.Range(10.0f, -8.0f);
            float rndy = Random.Range(1.5f, 6.0f);
            Instantiate(HPitem, new Vector3(105.0f, rndy, rndz), Quaternion.Euler(0, 0, 0));
        }
        Invoke("InstantiateHPitem", 8f);
    }

    //爆弾item
    private void InstantiateBombitem()
    {

        if (HP.CheckHP() <= 40)
        {
            float rndz = Random.Range(10.0f, -8.0f);
            float rndy = Random.Range(1.5f, 6.0f);
            Instantiate(Bombitem, new Vector3(105.0f, rndy, rndz), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            float rand = Random.Range(0, 3);
            if (rand == 0)
            {
                float rndz = Random.Range(10.0f, -8.0f);
                float rndy = Random.Range(1.5f, 6.0f);
                Instantiate(Bombitem, new Vector3(105.0f, rndy, rndz), Quaternion.Euler(0, 0, 0));
            }
        }

        Invoke("InstantiateBombitem", 6.0f);
    }

    ////////////////////////////Easy///////////////////////////////////

    //横バー
    void stage()
    {
        float x = Random.Range(1.5f, 6.0f);
        int rnd = Random.Range(1, 3);

        if (rnd % 2 == 0)
        {
            // プレハブを元にオブジェクトを生成する
            GameObject instance = Instantiate(obj, new Vector3(105.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else
        {
            // プレハブを元にオブジェクトを生成する
            GameObject instance = Instantiate(Redobj, new Vector3(105.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
        }

        if (timer < 20)
        {
            Invoke("stage", 2);
        }
        else
        {
            Invoke("stage2", 2);
        }
    }
    //縦バー
    void stage2()
    {
        float x = Random.Range(10.0f, -8.0f);
        int rnd = Random.Range(1, 3);

        if (rnd % 2 == 0)
        {
            // プレハブを元にオブジェクトを生成する
            GameObject instance = Instantiate(obj2, new Vector3(105.0f, 6.5f, x), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            // プレハブを元にオブジェクトを生成する
            GameObject instance = Instantiate(Redobj2, new Vector3(105.0f, 6.5f, x), Quaternion.Euler(0, 0, 0));
        }

        if (timer < 35)
        {
            Invoke("stage2", 2);
        }
        else
        {
            Invoke("Warpstage", 10);
        }
        
    }
    //追尾型スパイク
    void MoveSpikeBall()
    {
        Instantiate(SpikeBall, new Vector3(194.0f, 5f, Random.Range(10.0f, -8.0f)), Quaternion.Euler(0, 0, 0));


        Invoke("MoveSpikeBall", 4);
    }
    //突進型スパイク
    void MoveSpikeBall2()
    {
        Instantiate(SpikeBall2, new Vector3(194.0f, 2f, Random.Range(10.0f, -8.0f)), Quaternion.Euler(0, 0, 0));

        Invoke("MoveSpikeBall2", Random.Range(1.0f,2.5f));
    }
    //ワープ
    void Warpstage()
    {
      
        //プレハブを元にオブジェクトを生成する
        Instantiate(RedWarp);
        Instantiate(Warp);

        Invoke("MoveSpikeBall", 3);
        Invoke("MoveSpikeBall2", 2);
    }
    //後ろから流れてるボール
    void BackWall()
    {
        float y = Random.Range(-15.0f, 30.0f);
        float z = Random.Range(-57.0f, 57.0f);

        if (y < 17 && y > -5 && z < 20 && z > -20)
        {
        }
        else
        {
            Instantiate(MainBackWall, new Vector3(194.0f, y, z), Quaternion.Euler(0, 0, 0));
        }

        y = Random.Range(-15.0f, 30.0f);
        z = Random.Range(-57.0f, 57.0f);

        if (y < 17 && y > -5 && z < 20 && z > -20)
        {
        }
        else
        {
            Instantiate(MainBackWall2, new Vector3(194.0f, y, z), Quaternion.Euler(0, 0, 0));
        }

        Invoke("BackWall", 0.25f);
    }

    ////////////////////////////Normal///////////////////////////////////
    
    //横バー
    void Normalstage()
    {
        float x = Random.Range(1.5f, 6.0f);
        int rnd = Random.Range(1, 3);

        if (rnd % 2 == 0)
        {
            // プレハブを元にオブジェクトを生成する
            GameObject instance = Instantiate(Normalobj, new Vector3(105.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else
        {
            // プレハブを元にオブジェクトを生成する
            GameObject instance = Instantiate(NormalRedobj, new Vector3(105.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
        }

        if (timer < 35)
        {
            Invoke("Normalstage2", 2);
        }
        else
        {
            Invoke("Normalstage2", 2);
        }
    }
    //縦バー
    void Normalstage2()
    {
        float x = Random.Range(10.0f, -8.0f);
        int rnd = Random.Range(1, 3);

        if (rnd % 2 == 0)
        {
            // プレハブを元にオブジェクトを生成する
            GameObject instance = Instantiate(obj2, new Vector3(105.0f, 6.5f, x), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            // プレハブを元にオブジェクトを生成する
            GameObject instance = Instantiate(Redobj2, new Vector3(105.0f, 6.5f, x), Quaternion.Euler(0, 0, 0));
        }

        if (timer < 35)
        {
            Invoke("Normalstage", 2);
        }
        else
        {
            Invoke("NormalWarpstage", 10);
        }

    }
    //追尾型スパイク
    void NormalMoveSpikeBall()
    {
        Instantiate(SpikeBall, new Vector3(194.0f, 5f, Random.Range(10.0f, -8.0f)), Quaternion.Euler(0, 0, 0));

        if (timer < 60)
        {
            Invoke("NormalMoveSpikeBall", 3);
        }
    }
    //突進型スパイク
    void NormalMoveSpikeBall2()
    {
        Instantiate(SpikeBall2, new Vector3(194.0f, 2f, Random.Range(10.0f, -8.0f)), Quaternion.Euler(0, 0, 0));

        if (timer < 60)
        {
            Invoke("NormalMoveSpikeBall2", Random.Range(0.5f, 1.5f));
        }
        else
        {
            Destroy(RedWarp);
            Destroy(Warp);
            Invoke("NormalAnaWall",4);
        }
    }
    //ワープ
    void NormalWarpstage()
    {
        //プレハブを元にオブジェクトを生成する
        RedWarp = Instantiate(RedWarp);
        Warp    = Instantiate(Warp);

        Invoke("NormalMoveSpikeBall", 3);
        Invoke("NormalMoveSpikeBall2", 2);
    }
    //穴が開いているカベ
    void NormalAnaWall()
    {
        int rand = Random.Range(0, 6);

        if(rand == 0)
        {
            Instantiate(Ana, new Vector3(194.0f, 5.0f,1.0f), Quaternion.Euler(90, 0, 0));
        }
        else if (rand == 1)
        {
            Instantiate(Ana2, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else if (rand == 2)
        {
            Instantiate(Ana3, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else if (rand == 3)
        {
            Instantiate(AnaRed, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else if (rand == 4)
        {
            Instantiate(AnaRed2, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else if (rand == 5)
        {
            Instantiate(AnaRed3, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }

        Invoke("NormalAnaWall", 2.5f);
    }

    ////////////////////////////Herd///////////////////////////////////

    //横バー
    void Herdstage()
    {
        float x = Random.Range(1.5f, 6.0f);
        int rnd = Random.Range(1, 3);

        if (rnd % 2 == 0)
        {
            // プレハブを元にオブジェクトを生成する
            Instantiate(Normalobj, new Vector3(105.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
            x = Random.Range(1.5f, 6.0f);
            // プレハブを元にオブジェクトを生成する
            Instantiate(Normalobj, new Vector3(107.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else
        {
            // プレハブを元にオブジェクトを生成する
            Instantiate(NormalRedobj, new Vector3(105.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
            x = Random.Range(1.5f, 6.0f);
            // プレハブを元にオブジェクトを生成する
            Instantiate(NormalRedobj, new Vector3(107.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
        }


        if (timer < 35)
        {
            Invoke("Herdstage2", 2);
        }
        else
        {
            Invoke("HerdWarpstage", 10);
        }

    }
    //縦バー
    void Herdstage2()
    {
        float x = Random.Range(10.0f, -8.0f);
        int rnd = Random.Range(1, 3);

        for (int i = 0; i < rnd % 2 + 6; i++)
        {
            x = Random.Range(10.0f, -8.0f);

            if (rnd % 2 == 0)
            {
                // プレハブを元にオブジェクトを生成する
                GameObject instance = Instantiate(Herdobj, new Vector3(105.0f, 6.5f, x), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                // プレハブを元にオブジェクトを生成する
                GameObject instance = Instantiate(HerdRedobj, new Vector3(105.0f, 6.5f, x), Quaternion.Euler(0, 0, 0));
            }
        }

        if (timer < 35)
        {
            Invoke("Herdstage", 2);
        }
        else
        {
            Invoke("HerdWarpstage", 10);
        }

    }
    //追尾型スパイク
    void HerdMoveSpikeBall()
    {
        Instantiate(SpikeBall, new Vector3(194.0f, 5f, Random.Range(10.0f, -8.0f)), Quaternion.Euler(0, 0, 0));

        if (timer < 60)
        {
            Invoke("NormalMoveSpikeBall", 3);
        }
    }
    //突進型スパイク
    void HerdMoveSpikeBall2()
    {
        Instantiate(SpikeBall2, new Vector3(194.0f, 2f, Random.Range(10.0f, -8.0f)), Quaternion.Euler(0, 0, 0));

        if (timer < 60)
        {
            Invoke("NormalMoveSpikeBall2", Random.Range(0.5f, 1.5f));
        }
        else
        {
            Destroy(RedWarp);
            Destroy(Warp);
            Invoke("NormalAnaWall", 4);
        }
    }
    //ワープ
    void HerdWarpstage()
    {
        //プレハブを元にオブジェクトを生成する
        RedWarp = Instantiate(RedWarp);
        Warp = Instantiate(Warp);

        Invoke("HerdMoveSpikeBall", 3);
        Invoke("HerdMoveSpikeBall2", 2);
    }
    //穴が開いているカベ
    void HerdAnaWall()
    {
        int rand = Random.Range(0, 6);

        if (rand == 0)
        {
            Instantiate(Ana, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else if (rand == 1)
        {
            Instantiate(Ana2, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else if (rand == 2)
        {
            Instantiate(Ana3, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else if (rand == 3)
        {
            Instantiate(AnaRed, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else if (rand == 4)
        {
            Instantiate(AnaRed2, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else if (rand == 5)
        {
            Instantiate(AnaRed3, new Vector3(194.0f, 5.0f, 1.0f), Quaternion.Euler(90, 0, 0));
        }

        Invoke("NormalAnaWall", 2.5f);
    }

}
