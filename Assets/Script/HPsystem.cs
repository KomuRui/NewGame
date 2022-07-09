using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPsystem : MonoBehaviour
{
    [SerializeField]Slider HPbar;
    [SerializeField]float HP;
    float maxHP = 100;
    public GameObject ResultScore;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        HPbar.maxValue = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HPbar.value = HP;
        if(CheckHP() <= 0)
        {
            Time.timeScale = 0f;
            Instantiate(ResultScore);
            HP = 100;
        }
    }

    public void Damege(int damege)
    {
        HP -= damege;
        if (HP < 0)
        {
            HP = 0;
        }
        HPbar.value = HP;
    }

    public float CheckHP()
    {
        return HP;
    }

    public void PlusHP(int plus)
    {
        HP += plus;
        if(HP > maxHP)
        {
            HP = maxHP;
        }
        HPbar.value = HP;
    }
}
