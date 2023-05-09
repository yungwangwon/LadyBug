using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemname;
    public float movespeed;

	public bool istriger;
	float scalespeed;

	//Ǯ�� �������� �ٽ� Ȱ��ȭ �������
	private void OnEnable()
	{
		transform.localScale = new Vector3(1.0f, 1.0f, 0);
		scalespeed = 0.1f;
		istriger = false;
		movespeed = 1.0f;
	}

	// Update is called once per frame
	void Update()
    {
		transform.position += Vector3.down * movespeed * Time.deltaTime;

		//�÷��̾ �Ծ Ȱ��ȭ�� �Ǿ��ٸ�
		if (istriger)
		{
			switch (itemname)
			{
				//�����ۿ� ���� �ӵ� ����
				case "Bee":
					if (transform.localScale.x > 3.0f)
					{
						scalespeed = 0;
						return;
					}
					break;
				case "Flower":
					transform.Rotate(new Vector3(0, 0, 1));
					if (transform.localScale.x > 4.0f)
					{
						scalespeed = 0;
						return;
					}
					break;

			}
			transform.localScale += new Vector3(scalespeed, scalespeed, 0);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Debug.Log("�浹 �÷��̾�, ������");
			istriger = true;
			switch (itemname)
			{
				//�����ۿ� ���� �ӵ� ����
				case "Bee":
					movespeed = 0.5f;
					break;
				case "Flower":
					movespeed = 0;
					Invoke("DestroyFlower", 7.5f);
					break;
			}

			movespeed *= -1;
		}	
	}

	public bool GetisTriger()
	{
		return istriger;
	}

	void DestroyFlower()
	{
		gameObject.SetActive(false);
	}
}
