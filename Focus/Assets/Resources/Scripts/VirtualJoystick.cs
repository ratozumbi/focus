using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;	

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	[SerializeField] private Image bgImg;
    [SerializeField] private Image joyImg;
	private Vector3 inputVector;
		
	public float Horizontal(){
		if (inputVector.x != 0) {
			return inputVector.x;
		} else {
			return Input.GetAxis ("Horizontal");
		}
	}

	public float Vertical(){
		if (inputVector.z != 0) {
			return inputVector.z;
		} else {
			return Input.GetAxis ("Vertical");
		}
	}


	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
		Vibration.Vibrate (50);
	}
	public virtual void OnPointerUp(PointerEventData ped){

		inputVector = Vector3.zero;
		joyImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
		
			inputVector = new Vector3 (pos.x * 2 + 1, 0, pos.y * 2 - 1);

			inputVector = inputVector.magnitude > 1 ? inputVector.normalized : inputVector;

			joyImg.rectTransform.anchoredPosition = new Vector3 (inputVector.x * bgImg.rectTransform.sizeDelta.x / 3, inputVector.z * bgImg.rectTransform.sizeDelta.y / 3);
		}
	}
}
