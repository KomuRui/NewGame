using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menyu : MonoBehaviour
{
	[SerializeField]
	//�@�|�[�Y�������ɕ\������UI�̃v���n�u
	private GameObject MenyuPrefab;
	//�@�|�[�YUI�̃C���X�^���X
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
