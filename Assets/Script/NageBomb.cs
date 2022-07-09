using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NageBomb : MonoBehaviour
{
    //エフェクトONOF
    GameObject Efeect;

    // Start is called before the first frame update
    void Start()
    {
        //エフェクト
        Efeect = transform.Find("Baku").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(28.0f * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter(Collision other) //地面に触れた時の処理
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Wall2")
        {
            Efeect.SetActive(true);
            Invoke("Destory", 0.5f);
        }
    }

    void Destory()
    {
        Destroy(this.gameObject);
    }
}
