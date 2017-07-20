using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;	

public class Bounce : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image bixo;
	private Image chess;
	private Vector3 inputVector;



	private bool touch1 = false;


	public float maxX = 1000;
	public float maxY = 1000;

	public Vector2 velocity = new Vector2(1,1);

	// Use this for initialization
	void Start () {

		bixo = GameObject.Find ("bixoFocus").GetComponent<Image>();
		chess = GameObject.Find ("chess").GetComponent<Image>();
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (velocity * Time.deltaTime);
		if (transform.position.x >= maxX || transform.position.x <= maxX) {
			velocity = Vector2.Reflect (velocity, new Vector2 (1, 0));
			velocity *= 0.8f;
		}
		if (transform.position.y >= maxY || transform.position.y <= maxY) {
			velocity = Vector2.Reflect (velocity, new Vector2 (0, 1));
			velocity *= 0.8f;
		}
	}
	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
		Vibration.Vibrate (50);
		if (touch1 == false) {
			chess.transform.SetSiblingIndex (chess.transform.GetSiblingIndex () - 1);
		}
		touch1 = true;
	}
	public virtual void OnPointerUp(PointerEventData ped){

		float y = GameObject.Find ("bixoFocus").transform.localPosition.y;
		if (y < -900 && touch1 == true) {
			bixo.enabled = false;
			touch1 = false;

			GameObject.Find ("HandleEQ").GetComponent<Image>().enabled = true;
			chess.transform.SetSiblingIndex (chess.transform.GetSiblingIndex () - 1);

			//Destroy (GameObject.Find ("bixoFocus"));
		}
	
	}

	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (chess.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / chess.rectTransform.sizeDelta.x);
			pos.y = (pos.y / chess.rectTransform.sizeDelta.y);

			inputVector.x = pos.x;//new Vector3 (pos.x * 2 + 1, 0, pos.y * 2 - 1);

			inputVector.z = pos.y;//new Vector3 (pos.x * 2 + 1, 0, pos.y * 2 - 1);

			//inputVector = inputVector.magnitude > 1 ? inputVector.normalized : inputVector;

			bixo.rectTransform.anchoredPosition = new Vector3 (inputVector.x * chess.rectTransform.sizeDelta.x , inputVector.z * chess.rectTransform.sizeDelta.y );

		}
	}
}
