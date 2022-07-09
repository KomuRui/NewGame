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
        // y�������ɂ���5�x�Ax�������ɂ���5�x�A��]������Quaternion���쐬�i�ϐ���rot�Ƃ���j
        Quaternion rot = Quaternion.Euler(0, RotateSpeed * Time.deltaTime, RotateSpeed * Time.deltaTime);
        // ���݂̎��M�̉�]�̏����擾����B
        Quaternion q = this.transform.rotation;
        // �������āA���g�ɐݒ�
        this.transform.rotation = q * rot;

        this.gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);


        if (transform.position.x < -7)
        {
            Destroy(this.gameObject);
        }
    }
}
