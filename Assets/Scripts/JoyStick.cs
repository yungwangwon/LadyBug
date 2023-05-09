using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems; // Ű����, ���콺, ��ġ�� �̺�Ʈ�� ������Ʈ�� ���� �� �ִ� ����� ����

public class JoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Vector3 inputDir;
	[SerializeField]
	private RectTransform lever;
	private RectTransform rectTransform;
	[SerializeField, Range(10f, 150f)]
	private float leverRange;

	private Vector2 inputVector;    // �߰�
	private bool isInput;    // �߰�

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		ControlJoystickLever(eventData);  // �߰�
		isInput = true;    // �߰�
	}

	// ������Ʈ�� Ŭ���ؼ� �巡�� �ϴ� ���߿� ������ �̺�Ʈ
	// ������ Ŭ���� ������ ���·� ���콺�� ���߸� �̺�Ʈ�� ������ ����    
	public void OnDrag(PointerEventData eventData)
	{
		ControlJoystickLever(eventData);    
		isInput = true;    
	}

	public void ControlJoystickLever(PointerEventData eventData)
	{
		inputDir = eventData.position - rectTransform.anchoredPosition;
		//���� ��輳�� 
		var clampedDir = inputDir.magnitude < leverRange ? inputDir
			: inputDir.normalized * leverRange;

		lever.anchoredPosition = clampedDir;	//���� ��ġ ����

		inputVector = clampedDir.normalized;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		lever.anchoredPosition = Vector2.zero;
		isInput = false;    // �߰�

	}

	//���� ���⺤�Ͱ�
	public Vector2 GetJoyStickVec()
	{
		return inputVector;
	}

	//����
	public bool GetisInput()
	{
		return isInput;
	}
}
