using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class itemBox : MonoBehaviour
{
    //Solt���󂢂Ă�����A�^�񒆂��珇�Ԃɓ����

    [SerializeField]  Slot[] slots;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Sprite[] Afterimage = { slots[0].Getimage(), slots[1].Getimage(), slots[2].Getimage() };

            //for (int i = 0; i < slots.Length; i++)
            //{
            //    Afterimage[i] = slots[i].Getimage();
            //}

            slots[2].Setimage(Afterimage[1]);
            slots[1].Setimage(Afterimage[0]);
            slots[0].Setimage(Afterimage[2]);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Sprite[] Afterimage = { slots[0].Getimage(), slots[1].Getimage(), slots[2].Getimage() };

            //for (int i = 0; i < slots.Length; i++)
            //{
            //    Afterimage[i] = slots[i].Getimage();
            //}

            slots[2].Setimage(Afterimage[0]);
            slots[1].Setimage(Afterimage[2]);
            slots[0].Setimage(Afterimage[1]);

        }
    }

    //�ǂ��ł����s�ł�����
    public static itemBox instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
        public void Setitem(GameObject item)
    {
        //�󂢂Ă�����A�C�e�����Z�b�g����
        if(slots[2].IsEmpty())
        {
            slots[2].Setitem(item);
        }
        else if(slots[0].IsEmpty())
        {
            slots[0].Setitem(item);
        }
        else if (slots[1].IsEmpty())
        {
            slots[1].Setitem(item);
        }
       
    }
}
