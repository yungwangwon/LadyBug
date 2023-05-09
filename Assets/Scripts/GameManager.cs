using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnpoint;

    //���� �����̼���
	public float nextspawndelay;
	public float curspawndelay;

	public int score;   //���� ����

    public ObjectManager objmanager;
    public GameObject player;
	public TextMeshProUGUI scoretext;

	void Start()
    {
        score = 0;
		SpawnItem();

	}

	// Update is called once per frame
	void Update()
    {
        //������ ������ ����
		curspawndelay += Time.deltaTime;
		if (curspawndelay > nextspawndelay)
		{
			SpawnEnemy();
			curspawndelay = 0;
		}

		scoretext.text = string.Format("score : {0}", score);
	}

    void SpawnEnemy()
    {
        //Ǯ���� �̿��� ������
        GameObject enemy = objmanager.MakeObj("enemy");
        Enemy enemylogic = enemy.GetComponent<Enemy>();

        //��������Ʈ ����, ���� ����
		int rand = Random.Range(0, spawnpoint.Length);
        enemy.transform.position = spawnpoint[rand].position;
        enemylogic.SetDir(player.transform.position - enemy.transform.position);

    }

	//������ ����
    void SpawnItem()
    {
		GameObject spawnitem = null;
		//���� ������ ����
		switch (Random.Range(1, 2))
        {
            case 0: //itembee ����
				spawnitem = objmanager.MakeObj("itembee");
				break;
            case 1: //itemflower ����
				spawnitem = objmanager.MakeObj("itemflower");
				break;
        }

		int rand = Random.Range(1, 4);
		spawnitem.transform.position = spawnpoint[rand].position;

        Invoke("SpawnItem", 10);
	}

	// ���ھ� ����
	public void SetMaxScore()
	{
		int savedscore = PlayerPrefs.GetInt("MaxScore");
		if (savedscore <= score)
		{
			PlayerPrefs.SetInt("MaxScore", score);
		}
	}
}
