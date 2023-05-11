using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Vector3 dir;
    // Start is called before the first frame update
    public float movespeed;
	ObjectManager objmanager;
	GameManager gamemanager;

	void Awake()
    {
		gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
		objmanager = GameObject.Find("ObjManager").GetComponent<ObjectManager>();


	}

	private void OnEnable()
	{
		//dir = (player.transform.position - transform.position).normalized;
	}

	// Update is called once per frame
	void Update()
    {
        transform.position += dir * movespeed * Time.deltaTime;
    }

	//충돌
	private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌");
		if (collision.tag == "Board")
		{
			gameObject.SetActive(false);
		}
		else if (collision.tag == "Item")
		{
			Debug.Log("충돌 적, 아이템");
			Item itemlogic = collision.transform.GetComponentInParent<Item>();
			if (!itemlogic.istriger)
				return;

			// 스코어++
			gamemanager.score += Random.Range(5, 10) * 5;

			int rand = Random.Range(0, 10);
			if (rand < 6) // 꽝 60%
				Debug.Log("Not Item");
			else if (rand == 6) // Bee 10%
			{
				GameObject ItemBee = objmanager.MakeObj("itembee");
				ItemBee.transform.position = transform.position;
			}
			else if (rand == 7) // Flower 10%
			{
				GameObject ItemFlower = objmanager.MakeObj("itemflower");
				ItemFlower.transform.position = transform.position;
			}
			else
				Debug.Log("Not Item");
			gameObject.SetActive(false);
		}
	
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		OnTriggerEnter2D(collision);
	}


	//방향 설정
	public void SetDir(Vector2 pvec, Vector2 evec)
    {
		dir = (pvec - evec).normalized;

		transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90);
	}
}
