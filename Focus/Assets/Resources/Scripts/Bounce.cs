using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;	

public class Bounce : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image bixoImage;
	private RawImage chess;
	private Vector3 inputVector;

	private bool reflectX = false;
	private bool reflectY = false;



	private bool touch1time = false;


	public float maxX = 700;
	public float maxY = 1100;

	public float speed = 1000f;

	private bool canMove = true;
	private Vector2 velocity = new Vector2(1,1);
    private Canvas canvas;
    private Camera camera;


    // Use this for initialization
    void Start () {

		velocity *= speed;
        bixoImage = GameObject.Find("bixoFocus").GetComponent<Image>();
        chess = GameObject.Find ("chess").GetComponent<RawImage>();

        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();


    }
	
	// Update is called once per frame
	void Update () {

        if (canMove)
            move();

    }
    public virtual void OnPointerDown(PointerEventData ped){
		canMove = false;
        reflectY = false;
        reflectX = false;

        Vibration.Vibrate (50);
		if (touch1time == false) {
			chess.transform.SetSiblingIndex (chess.transform.GetSiblingIndex () - 1);
		}
		touch1time = true;
	}

    public virtual void OnPointerUp(PointerEventData ped){
		canMove = true;
        //velocity = Vector2.Reflect (velocity.normalized * speed, velocity.normalized);//

        GameObject barra = GameObject.Find("qtdFoco");
        GameObject bixoObj = GameObject.Find ("bixoFocus");
        float dist = Vector2.Distance(barra.transform.position, bixoObj.transform.position);
        Debug.Log(dist);

        if (dist < 1 && touch1time == true) {
			bixoImage.enabled = false;
			touch1time = false;

			GameObject.Find ("HandleEQ").GetComponent<Image>().enabled = true;
			chess.transform.SetSiblingIndex (chess.transform.GetSiblingIndex () - 1);
            
		}
	
	}

    public virtual void OnDrag(PointerEventData ped){
        transform.localPosition = new Vector3((ped.position.x / canvas.scaleFactor) - ((camera.pixelWidth / 2) / canvas.scaleFactor), 
            (ped.position.y / canvas.scaleFactor) - ((camera.pixelHeight/2) / canvas.scaleFactor));
        //transform.position = ped.position;
	}

void move()
    {

        transform.Translate(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, 0);

        if ((transform.localPosition.x >= maxX && velocity.normalized.x > 0) || (transform.localPosition.x <= (maxX * -1) && velocity.normalized.x < 0))
        {

            if (!reflectX) {
				velocity = Vector2.Reflect (velocity.normalized * speed, new Vector2 (1, 0));
				reflectX = true;
			}

		} else {
			reflectX = false;
		}

		if ((transform.localPosition.y >= maxY && velocity.normalized.y > 0) || (transform.localPosition.y <= (maxY*-1) && velocity.normalized.y < 0)) {
			
			if (!reflectY) {
				reflectY = true;
				velocity = Vector2.Reflect (velocity.normalized * speed, new Vector2 (0, 1));
			}

		} else {
			reflectY = false;
		}
        
    }
}
