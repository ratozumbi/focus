using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControler : MonoBehaviour {

	private GameObject bixoFocus;
	private GameObject chess;
	private BarraFocus barraFocus;
	private BarraEquilibrio barraEquilibrio;

	public float timeWaitSpaw = 1f;
	public float timeLastSpaw = 0f;

	// Use this for initialization
	void Start () {
		bixoFocus = GameObject.Find ("bixoFocus") as GameObject;
		chess = GameObject.Find ("chess");
		barraFocus = GameObject.Find ("qtdFoco").GetComponent<BarraFocus> ();
		barraEquilibrio = GameObject.Find ("equilibrio").GetComponent<BarraEquilibrio> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (bixoFocus.GetComponent<Image>().enabled == false) {

			barraEquilibrio = GameObject.Find ("equilibrio").GetComponent<BarraEquilibrio> ();

			if(barraEquilibrio.slide.value >0.4f && barraEquilibrio.slide.value <0.6f && barraFocus.slide.value <5.0f){ 
				if (Time.realtimeSinceStartup - timeLastSpaw > timeWaitSpaw) {
					timeLastSpaw = Time.realtimeSinceStartup;
					spawBolha ();
				}
			}

		}

	}

	void spawBolha(){
		
		Vector2 pos = GameObject.Find("Canvas").transform.position;
		Vector2 circ;
		circ = Random.insideUnitCircle;
		circ.x = circ.x*600;
		circ.y = circ.y * 1200;
		pos = pos + circ;
		GameObject bolha = Instantiate(Resources.Load("bolha"),pos, transform.rotation, GameObject.Find("Canvas").transform) as GameObject;
		
	}
}
