using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingCounter : MonoBehaviour
{
    public static int[] Score =  { 0,0,0,0,0 };

    // Start is called before the first frame update
    void Start()
    {
        Text[] textComponent = { GameObject.Find("iti").GetComponent<Text>(), GameObject.Find("iti2").GetComponent<Text>(), GameObject.Find("iti3").GetComponent<Text>(), GameObject.Find("iti4").GetComponent<Text>(), GameObject.Find("iti5").GetComponent<Text>(), };


        if (Score[0] == 0)
        { 
            Score[0] = GetScore();
        }
        else
        {
            for(int i = 1; i < 5; i++)
            {
                if(Score[i] == 0)
                {
                    Score[i] = GetScore();
                    break;
                }
            }
        }

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i > j)
                {
                    if (Score[j] < Score[i])
                    {
                        int a = Score[j];
                        int b = Score[i];

                        Score[i] = a;
                        Score[j] = b;
                    }
                }
                else if(j > i)
                {
                    if (Score[j] > Score[i])
                    {
                        int a = Score[j];
                        int b = Score[i];

                        Score[i] = a;
                        Score[j] = b;
                    }
                }
            }
              
        }


            for (int i = 0; i < textComponent.Length; i++)
        {
            textComponent[i].text = i + 1.ToString() + "ˆÊ : name " + Score[i].ToString();
        }
    }


     public int GetScore()
     {
        if (ScoreController.score >= 0)
            return ScoreController.score;

        return 0;
     }
   
}
