using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems; // 키보드, 마우스, 터치를 이벤트로 오브젝트에 보낼 수 있는 기능을 지원

public class JoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Vector3 inputDir;
	[SerializeField]
	private RectTransform lever;
	private RectTransform rectTransform;
	[SerializeField, Range(10f, 150f)]
	private float leverRange;

	private Vector2 inputVector;    // 추가
	private bool isInput;    // 추가

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		ControlJoystickLever(eventData);  // 추가
		isInput = true;    // 추가
	}

	// 오브젝트를 클릭해서 드래그 하는 도중에 들어오는 이벤트
	// 하지만 클릭을 유지한 상태로 마우스를 멈추면 이벤트가 들어오지 않음    
	public void OnDrag(PointerEventData eventData)
	{
		ControlJoystickLever(eventData);    
		isInput = true;    
	}

	public void ControlJoystickLever(PointerEventData eventData)
	{
		inputDir = eventData.position - rectTransform.anchoredPosition;
		//레버 경계설정 
		var clampedDir = inputDir.magnitude < leverRange ? inputDir
			: inputDir.normalized * leverRange;

		lever.anchoredPosition = clampedDir;	//레버 위치 적용

		inputVector = clampedDir.normalized;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		lever.anchoredPosition = Vector2.zero;
		isInput = false;    // 추가

	}

	//조작 방향벡터값
	public Vector2 GetJoyStickVec()
	{
		return inputVector;
	}

	//조작
	public bool GetisInput()
	{
		return isInput;
	}
}
