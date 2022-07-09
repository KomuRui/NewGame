using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficuleMove : MonoBehaviour
{
    public RectTransform[] arrow;
    public float move = 0.5f;
    bool flag = false;
    bool flag2 = false;
    int[] x;

    public GameObject Button;
    public GameObject Button2;

    void Start()
    {
        x = new int[arrow.Length];
        for (int i = 0; i < arrow.Length; i++)
        {
            x[i] = (int)arrow[i].position.x;
        }

    }

    void Update()
    {
        for (int i = 0; i < arrow.Length; i++)
        {
            if (flag)
            {
                if ((int)arrow[i].position.x != x[i])
                {
                    arrow[i].position -= new Vector3(move * Time.deltaTime, 0, 0);
                    Button2.GetComponent<CanvasGroup>().alpha = 0;
                    Button.GetComponent<CanvasGroup>().alpha = 0;
                }
                else
                {
                    if ((int)(arrow[0].position.x - 960) != 0)
                    {
                        Button2.GetComponent<CanvasGroup>().alpha = 1;
                    }
                    if((int)arrow[i].position.x == x[i])
                    {
                        Button2.GetComponent<CanvasGroup>().alpha = 1;
                        Button.GetComponent<CanvasGroup>().alpha = 1;
                    }
                    flag = false;
                }
            }
            if(flag2)
            {
                if ((int)arrow[i].position.x != x[i])
                {
                    arrow[i].position += new Vector3(move * Time.deltaTime, 0, 0);
                    Button2.GetComponent<CanvasGroup>().alpha = 0;
                    Button.GetComponent<CanvasGroup>().alpha = 0;
                }
                else
                {
                    if ((int)(arrow[3].position.x - 960) != 0)
                    {
                        Button.GetComponent<CanvasGroup>().alpha = 1;
                    }
                    if ((int)arrow[i].position.x == x[i])
                    {
                        Button2.GetComponent<CanvasGroup>().alpha = 1;
                        Button.GetComponent<CanvasGroup>().alpha = 1;
                    }
                    flag2 = false;
                }
            }
        }

        if((int)(arrow[0].position.x - 960) == 0 || (int)(arrow[0].position.x - 960) == 1)
        {
            Button2.GetComponent<CanvasGroup>().alpha = 0;
        }
        if ((int)(arrow[3].position.x - 960) == 0 || (int)(arrow[3].position.x - 960) == 1)
        {
            Button.GetComponent<CanvasGroup>().alpha = 0;
        }

    }

    public void OnClickStartButton()
    {
        if (flag == false && flag2 == false)
        {
            for (int i = 0; i < arrow.Length; i++)
            {
                x[i] = (int)arrow[i].position.x - 960;
            }
            flag = true;
        }
        
    }

    public void OnClickStartButton2()
    {
        if (flag == false && flag2 == false)
        {
            for (int i = 0; i < arrow.Length; i++)
            {
                x[i] = (int)arrow[i].position.x + 960;
            }
            flag2 = true;
        }
    
    }

}

