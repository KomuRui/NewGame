using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultScore : MonoBehaviour
{
    Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        this.textComponent = GameObject.Find("ResultText").GetComponent<Text>();
        textComponent.text = GameObject.Find("Score").GetComponent<ScoreController>().Getscore().ToString();
        GameObject.Find("Score").SetActive(false);
        GameObject.Find("HPbar").SetActive(false);
        GameObject.Find("itemBox").SetActive(false);
    }

}
