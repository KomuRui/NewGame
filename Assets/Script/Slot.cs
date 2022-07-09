using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    //アイテムを受け取ったら画像をスロットに表示してやる
    Image image;

    public Sprite heal;
    public Sprite Bomb;
    public Sprite moto;

    void Start()
    {
        this.image.sprite = moto;
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public bool IsEmpty()
    {
        if (image.sprite == moto)
        {
            return true;
        }
        return false;
    }

    public void Setitem(GameObject item)
    {
        UpdateImage(item);
    }


    public Sprite Getimage()
    {
        return this.image.sprite;
    }

    public int GetPlayerImage()
    {
        if(this.image.sprite == heal)
        {
            return 1;
        }
        else if(this.image.sprite == Bomb)
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }

    public void Setmoto()
    {
        this.image.sprite = moto;
    }

    public void Setimage(Sprite image)
    {
        this.image.sprite = image;
    }

    void UpdateImage(GameObject item)
    {
        if(item.transform.tag == "heal")
        {
            image.sprite = heal;
        }
        else if(item.transform.tag == "Bomb")
        {
            image.sprite = Bomb;
        }
    }

}
