using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
        public static int score;
        public static string Name;
        Text textComponent;


        // Start is called before the first frame update
        void Start()
        {
            score = 0;
            this.textComponent = GameObject.Find("Score").GetComponent<Text>();
            this.textComponent.text = "Score " + score.ToString();

            Invoke("AddScore", 1);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void AddScore()
        {
            score += (int)Time.time;
            this.textComponent.text = "Score " + score.ToString();

            Invoke("AddScore", 1);
        }

        public int Getscore()
        {
            return score;
        }

        public string GetName()
        {
            return Name;
        }

}
