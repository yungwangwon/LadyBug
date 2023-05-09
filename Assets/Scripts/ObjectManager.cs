using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    //ÇÁ¸®Æé

    public GameObject enemyPrefab;

	public GameObject itemBeePrefab;
	public GameObject itemFlowerPrefab;

	GameObject[] enemy;


	GameObject[] itemflower;
	GameObject[] itembee;


	GameObject[] targetpool;
	private void Awake()
	{
		enemy = new GameObject[500];

		itemflower = new GameObject[10];
		itembee = new GameObject[10];

		Generate();
	}

	void Generate()
	{
		//Àû
		for (int i = 0; i < enemy.Length; i++)
		{
			enemy[i] = Instantiate(enemyPrefab);
			enemy[i].SetActive(false);
		}
		for (int i = 0; i < itemflower.Length; i++)
		{
			itemflower[i] = Instantiate(itemFlowerPrefab);
			itemflower[i].SetActive(false);
		}
		for (int i = 0; i < itembee.Length; i++)
		{
			itembee[i] = Instantiate(itemBeePrefab);
			itembee[i].SetActive(false);
		}
	}

	public GameObject MakeObj(string type)
	{
		switch (type) 
		{
			case "enemy":
				targetpool = enemy;
				break;
			case "itembee":
				targetpool = itembee;
				break;
			case "itemflower":
				targetpool = itemflower;
				break;

		}

		for(int i= 0; i < targetpool.Length; i++)
		{
			if (!targetpool[i].activeSelf)
			{
				targetpool[i].SetActive(true);
				return targetpool[i];
			}
		}

		return null;
	}

}
