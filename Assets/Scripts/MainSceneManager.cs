using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainSceneManager : MonoBehaviour
{
	public TextMeshProUGUI scoretext;

	public void GameStart()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void GetMaxScore()
	{
		int maxscore = PlayerPrefs.GetInt("MaxScore");
		scoretext.text = string.Format("{0}", maxscore);
	}
}
