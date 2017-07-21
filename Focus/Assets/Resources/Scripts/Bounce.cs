using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;	

public class Bounce : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image bixo;
	private Image chess;
	private Vector3 inputVector;

	private bool reflectX = false;
	private bool reflectY = false;



	private bool touch1time = false;


	public float maxX = 700;
	public float maxY = 1100;

	public float speed = 1000f;

	private bool canMove = true;
	private Vector2 velocity = new Vector2(1,1);

	// Use this for initialization
	void Start () {

		velocity *= speed;

		bixo = GameObject.Find ("bixoFocus").GetComponent<Image>();
		chess = GameObject.Find ("chess").GetComponent<Image>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (canMove)
			move ();
		
	}
	public virtual void OnPointerDown(PointerEventData ped){
		//OnDrag (ped);
		canMove = false;
		Vibration.Vibrate (50);
		if (touch1time == false) {
			chess.transform.SetSiblingIndex (chess.transform.GetSiblingIndex () - 1);
		}
		touch1time = true;
	}
	public virtual void OnPointerUp(PointerEventData ped){
		canMove = true;
		velocity = Vector2.Reflect (velocity.normalized * speed, velocity.normalized);

		float y = GameObject.Find ("bixoFocus").transform.localPosition.y;
		if (y < -900 && touch1time == true) {
			bixo.enabled = false;
			touch1time = false;

			GameObject.Find ("HandleEQ").GetComponent<Image>().enabled = true;
			chess.transform.SetSiblingIndex (chess.transform.GetSiblingIndex () - 1);

			//Destroy (this.gameObject);
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

	public void OnPointerClick( PointerEventData eventData )
	{
		Debug.Log( "Clicked!" );
	}

	void move(){

		transform.Translate (velocity * Time.deltaTime);

		if (transform.localPosition.x >= maxX || transform.localPosition.x <= (maxX * -1)) {

			if (!reflectX) {
				velocity = Vector2.Reflect (velocity.normalized * speed, new Vector2 (1, 0));
				reflectX = true;
			}

		} else {
			reflectX = false;
		}

		if (transform.localPosition.y >= maxY || transform.localPosition.y <= (maxY*-1)) {
			
			if (!reflectY) {
				reflectY = true;
				velocity = Vector2.Reflect (velocity.normalized * speed, new Vector2 (0, 1));
			}

		} else {
			reflectY = false;
		}



	}
}
