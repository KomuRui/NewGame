using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maneger : MonoBehaviour
{
    ///////////////////////�X�e�[�W///////////////////////////
    //���o�[
    GameObject obj;
    GameObject Redobj;
    GameObject Normalobj;
    GameObject NormalRedobj;
    GameObject Herdobj;
    GameObject HerdRedobj;

    //�c�o�[
    GameObject obj2;
    GameObject Redobj2;

    //���̔��ł��镨��
    GameObject MainBackWall;
    GameObject MainBackWall2;

    //���[�v�X�e�[�W
    GameObject Warp;
    GameObject RedWarp;
    GameObject SpikeBall;
    GameObject SpikeBall2;

    //�J�x
    GameObject Ana;
    GameObject Ana2;
    GameObject Ana3;
    GameObject AnaRed;
    GameObject AnaRed2;
    GameObject AnaRed3;

    //��Փx���
    public int difficulty = 1;
    private float timer;

    ///////////////////////�A�C�e��//////////////////////////////
    //HP�Ǘ�
    private HPsystem HP;
    GameObject HPitem;
    //���e
    GameObject Bombitem;

    void Start()
    {
        timer = 0.0f;

        ///////////////////////���o�[////////////////////////////
        obj = (GameObject)Resources.Load("Wall");
        Redobj = (GameObject)Resources.Load("RedWall");
        Normalobj = (GameObject)Resources.Load("NormalWall");
        NormalRedobj = (GameObject)Resources.Load("NormalRedWall");
        Herdobj = (GameObject)Resources.Load("HerdWall");
        HerdRedobj = (GameObject)Resources.Load("HerdRedWall");

        ///////////////////////�c�o�[////////////////////////////
        obj2 = (GameObject)Resources.Load("Wall2");
        Redobj2 = (GameObject)Resources.Load("RedWall2");

        ////////////////���̔��ł��镨��/////////////////////
        MainBackWall = (GameObject)Resources.Load("MainBackWall");
        MainBackWall2 = (GameObject)Resources.Load("MainBackWall2");
        Invoke("BackWall", 0.25f);

        ///////////////////////���[�v////////////////////////////
        Warp = (GameObject)Resources.Load("Warp");
        RedWarp = (GameObject)Resources.Load("RedWarp");
        SpikeBall = (GameObject)Resources.Load("SpikeBall");
        SpikeBall2 = (GameObject)Resources.Load("SpikeBall2");

        ///////////////////////�J�x/////////////////////////////
        Ana =    (GameObject)Resources.Load("Ana");
        Ana2 =   (GameObject)Resources.Load("Ana2");
        Ana3 =   (GameObject)Resources.Load("Ana3");
        AnaRed = (GameObject)Resources.Load("AnaRed");
        AnaRed2 = (GameObject)Resources.Load("AnaRed2");
        AnaRed3 = (GameObject)Resources.Load("AnaRed3");

        ///////////////////////�A�C�e��/////////////////////////
        HP = GameObject.Find("Manager").GetComponent<HPsystem>();
        HPitem = (GameObject)Resources.Load("HPobject");
        Bombitem = (GameObject)Resources.Load("Bomb");
        Invoke("InstantiateHPitem", 10f);
        Invoke("InstantiateBombitem", 6f);

        //��Փx���Ƃɕς���
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

    ////////////////////////////�A�C�e��///////////////////////////////////
    
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

    //���eitem
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

    //���o�[
    void stage()
    {
        float x = Random.Range(1.5f, 6.0f);
        int rnd = Random.Range(1, 3);

        if (rnd % 2 == 0)
        {
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            GameObject instance = Instantiate(obj, new Vector3(105.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else
        {
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
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
    //�c�o�[
    void stage2()
    {
        float x = Random.Range(10.0f, -8.0f);
        int rnd = Random.Range(1, 3);

        if (rnd % 2 == 0)
        {
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            GameObject instance = Instantiate(obj2, new Vector3(105.0f, 6.5f, x), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
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
    //�ǔ��^�X�p�C�N
    void MoveSpikeBall()
    {
        Instantiate(SpikeBall, new Vector3(194.0f, 5f, Random.Range(10.0f, -8.0f)), Quaternion.Euler(0, 0, 0));


        Invoke("MoveSpikeBall", 4);
    }
    //�ːi�^�X�p�C�N
    void MoveSpikeBall2()
    {
        Instantiate(SpikeBall2, new Vector3(194.0f, 2f, Random.Range(10.0f, -8.0f)), Quaternion.Euler(0, 0, 0));

        Invoke("MoveSpikeBall2", Random.Range(1.0f,2.5f));
    }
    //���[�v
    void Warpstage()
    {
      
        //�v���n�u�����ɃI�u�W�F�N�g�𐶐�����
        Instantiate(RedWarp);
        Instantiate(Warp);

        Invoke("MoveSpikeBall", 3);
        Invoke("MoveSpikeBall2", 2);
    }
    //��납�痬��Ă�{�[��
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
    
    //���o�[
    void Normalstage()
    {
        float x = Random.Range(1.5f, 6.0f);
        int rnd = Random.Range(1, 3);

        if (rnd % 2 == 0)
        {
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            GameObject instance = Instantiate(Normalobj, new Vector3(105.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else
        {
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
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
    //�c�o�[
    void Normalstage2()
    {
        float x = Random.Range(10.0f, -8.0f);
        int rnd = Random.Range(1, 3);

        if (rnd % 2 == 0)
        {
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            GameObject instance = Instantiate(obj2, new Vector3(105.0f, 6.5f, x), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
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
    //�ǔ��^�X�p�C�N
    void NormalMoveSpikeBall()
    {
        Instantiate(SpikeBall, new Vector3(194.0f, 5f, Random.Range(10.0f, -8.0f)), Quaternion.Euler(0, 0, 0));

        if (timer < 60)
        {
            Invoke("NormalMoveSpikeBall", 3);
        }
    }
    //�ːi�^�X�p�C�N
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
    //���[�v
    void NormalWarpstage()
    {
        //�v���n�u�����ɃI�u�W�F�N�g�𐶐�����
        RedWarp = Instantiate(RedWarp);
        Warp    = Instantiate(Warp);

        Invoke("NormalMoveSpikeBall", 3);
        Invoke("NormalMoveSpikeBall2", 2);
    }
    //�����J���Ă���J�x
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

    //���o�[
    void Herdstage()
    {
        float x = Random.Range(1.5f, 6.0f);
        int rnd = Random.Range(1, 3);

        if (rnd % 2 == 0)
        {
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            Instantiate(Normalobj, new Vector3(105.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
            x = Random.Range(1.5f, 6.0f);
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            Instantiate(Normalobj, new Vector3(107.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
        }
        else
        {
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            Instantiate(NormalRedobj, new Vector3(105.0f, x, 1.0f), Quaternion.Euler(90, 0, 0));
            x = Random.Range(1.5f, 6.0f);
            // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
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
    //�c�o�[
    void Herdstage2()
    {
        float x = Random.Range(10.0f, -8.0f);
        int rnd = Random.Range(1, 3);

        for (int i = 0; i < rnd % 2 + 6; i++)
        {
            x = Random.Range(10.0f, -8.0f);

            if (rnd % 2 == 0)
            {
                // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
                GameObject instance = Instantiate(Herdobj, new Vector3(105.0f, 6.5f, x), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
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
    //�ǔ��^�X�p�C�N
    void HerdMoveSpikeBall()
    {
        Instantiate(SpikeBall, new Vector3(194.0f, 5f, Random.Range(10.0f, -8.0f)), Quaternion.Euler(0, 0, 0));

        if (timer < 60)
        {
            Invoke("NormalMoveSpikeBall", 3);
        }
    }
    //�ːi�^�X�p�C�N
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
    //���[�v
    void HerdWarpstage()
    {
        //�v���n�u�����ɃI�u�W�F�N�g�𐶐�����
        RedWarp = Instantiate(RedWarp);
        Warp = Instantiate(Warp);

        Invoke("HerdMoveSpikeBall", 3);
        Invoke("HerdMoveSpikeBall2", 2);
    }
    //�����J���Ă���J�x
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
