using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBackWall : MonoBehaviour
{

    public float RotateSpeed = 60.0f;
    public float speed = 120.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // y軸を軸にして5度、x軸を軸にして5度、回転させるQuaternionを作成（変数をrotとする）
        Quaternion rot = Quaternion.Euler(0, RotateSpeed * Time.deltaTime, RotateSpeed * Time.deltaTime);
        // 現在の自信の回転の情報を取得する。
        Quaternion q = this.transform.rotation;
        // 合成して、自身に設定
        this.transform.rotation = q * rot;

        this.gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);


        if (transform.position.x < -7)
        {
            Destroy(this.gameObject);
        }
    }
}
