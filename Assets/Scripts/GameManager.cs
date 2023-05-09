using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnpoint;

    //스폰 딜레이설정
	public float nextspawndelay;
	public float curspawndelay;

	public int score;   //점수 변수

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
        //스폰에 딜레이 적용
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
        //풀링을 이용한 적생성
        GameObject enemy = objmanager.MakeObj("enemy");
        Enemy enemylogic = enemy.GetComponent<Enemy>();

        //스폰포인트 설정, 방향 설정
		int rand = Random.Range(0, spawnpoint.Length);
        enemy.transform.position = spawnpoint[rand].position;
        enemylogic.SetDir(player.transform.position - enemy.transform.position);

    }

	//아이템 생성
    void SpawnItem()
    {
		GameObject spawnitem = null;
		//랜덤 아이템 스폰
		switch (Random.Range(1, 2))
        {
            case 0: //itembee 스폰
				spawnitem = objmanager.MakeObj("itembee");
				break;
            case 1: //itemflower 스폰
				spawnitem = objmanager.MakeObj("itemflower");
				break;
        }

		int rand = Random.Range(1, 4);
		spawnitem.transform.position = spawnpoint[rand].position;

        Invoke("SpawnItem", 10);
	}

	// 스코어 저장
	public void SetMaxScore()
	{
		int savedscore = PlayerPrefs.GetInt("MaxScore");
		if (savedscore <= score)
		{
			PlayerPrefs.SetInt("MaxScore", score);
		}
	}
}
