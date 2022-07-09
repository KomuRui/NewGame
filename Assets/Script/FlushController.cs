using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour
{
	Image img;
	bool flag = false;
	void Start()
	{
		img = GetComponent<Image>();
		img.color = Color.clear;
	}

	void Update()
	{
		if (flag)
		{
			this.img.color = new Color(0.5f, 0f, 0f, 0.5f);
			flag = false;
		}
		else
		{
			this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
		}
	}

	public void Setflag()
    {
		flag = true;
    }
}
