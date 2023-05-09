using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    JoyStick joystick;
    Rigidbody2D rigid;

	public GameManager manager;

	[SerializeField]
	float movespeed;
	// Start is called before the first frame update
	void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = joystick.GetJoyStickVec();

        //플레이어 이동
		if (joystick.GetisInput())
			transform.position += dir * movespeed * Time.deltaTime;
		else
			rigid.velocity = Vector2.zero;

		//이동제한 (카메라 왼쪽하단(0,0), 오른쪽상단(1,1))
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		if (pos.x < 0f) pos.x = 0f;	//벗어났을경우
		if (pos.x > 1f) pos.x = 1f;
		if (pos.y < 0f) pos.y = 0f;
		if (pos.y > 1f) pos.y = 1f;
		transform.position = Camera.main.ViewportToWorldPoint(pos); //적용
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//적이랑 충돌했을시
		if (collision.tag == "Enemy")
		{
			manager.SetMaxScore();
			SceneManager.LoadScene("MainScene");
		}
	}

}
