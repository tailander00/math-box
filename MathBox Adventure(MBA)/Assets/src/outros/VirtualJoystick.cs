using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler{

	private Image bgJoy;
	private Image joy;
	private Vector3 vector;
	private bool movendo;

	void Start () {
		movendo = false;
		bgJoy = GetComponent<Image>();
		joy = transform.GetChild(0).GetComponent<Image>();
	}

	public virtual void OnPointerUp(PointerEventData ped){
		movendo = false;
		vector = Vector3.zero;
		joy.rectTransform.anchoredPosition = Vector3.zero;
		Jogador.jogador.setAxis(0,0);
	}

	public virtual void OnPointerDown(PointerEventData ped){
		movendo = true;
		OnDrag(ped);
	}

	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgJoy.rectTransform,ped.position,ped.pressEventCamera,out pos)){
			pos.x /= bgJoy.rectTransform.sizeDelta.x;
			pos.y /= bgJoy.rectTransform.sizeDelta.y;

			vector = new Vector3(pos.x *2,0, pos.y*2);

			if(vector.magnitude > 1.0f){
				vector = vector.normalized;
			}else{
				vector = vector;
			}

			joy.rectTransform.anchoredPosition = new Vector3(vector.x * (bgJoy.rectTransform.sizeDelta.x/3) , vector.z * (bgJoy.rectTransform.sizeDelta.y/3));
		}
	}

	void Update () {
		if(movendo)
			Jogador.jogador.setAxis(vector.x,vector.z);
	}
}
