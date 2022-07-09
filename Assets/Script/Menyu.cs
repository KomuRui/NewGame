using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menyu : MonoBehaviour
{
	[SerializeField]
	//　ポーズした時に表示するUIのプレハブ
	private GameObject MenyuPrefab;
	//　ポーズUIのインスタンス
	private GameObject menyuInstance;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (menyuInstance == null)
			{
				menyuInstance = GameObject.Instantiate(MenyuPrefab) as GameObject;
				Time.timeScale = 0f;
			}
			else
			{
				Destroy(menyuInstance);
				Time.timeScale = 1f;
			}
		}
	}
}
