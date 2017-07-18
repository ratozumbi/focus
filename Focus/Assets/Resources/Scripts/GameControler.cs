using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControler : MonoBehaviour {

	private GameObject bixoFocus;

	// Use this for initialization
	void Start () {
		bixoFocus = GameObject.Find ("bixoFocus") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (bixoFocus.GetComponent<Image>().enabled == false) {
			spawBolha ();
		}

	}

	void spawBolha(){
		
	}
}
