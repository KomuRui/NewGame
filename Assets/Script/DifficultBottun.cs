using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultBottun : MonoBehaviour
{
    public Fade[] fade;
    public GameObject Ranking;
    public GameObject Difficlut;
    public GameObject KeepRank;
    public GameObject ResultScore;

    public void OnClickStartButton()
    {
        fade[0].FadeIn(2f, () => SceneManager.LoadScene("EasyGameScene"));
    }

    public void OnClickStartButton2()
    {
        fade[1].FadeIn(2f, () => SceneManager.LoadScene("NormalGameScene"));
    }

    public void OnClickStartButton3()
    {
        fade[2].FadeIn(2f, () => SceneManager.LoadScene("HerdGameScene"));
    }

    public void OnClickStartButton4()
    {
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1f;
    }

    public void OnClickStartButton5()
    {
        Difficlut.SetActive(false);
        Ranking.SetActive(true);
    }

    public void OnClickStartButton6()
    {
        Difficlut.SetActive(true);
        Ranking.SetActive(false);
    }

    public void OnClickStartButton7()
    {
        ResultScore.SetActive(false);
        Instantiate(KeepRank);
    }

    public void OnClickStartButton8()
    {
        KeepRank.SetActive(false);
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1f;
    }
}
