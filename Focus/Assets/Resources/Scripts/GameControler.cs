﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControler : MonoBehaviour {

	private GameObject bixoFocus;
	private GameObject chess;
	private BarraFocus barraFocus;
	private BarraEquilibrio barraEquilibrio;
    private Canvas canvas;
    private Camera camera;

	public float timeWaitSpaw = 1f;
	public float timeLastSpaw = 0f;

	// Use this for initialization
	void Start () {
		bixoFocus = GameObject.Find ("bixoFocus") as GameObject;
		chess = GameObject.Find ("chess");
		barraFocus = GameObject.Find ("qtdFoco").GetComponent<BarraFocus> ();
		barraEquilibrio = GameObject.Find ("equilibrio").GetComponent<BarraEquilibrio> ();


        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();

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
		
		Vector2 pos;
		
        pos.x = Random.Range(-(camera.pixelWidth / canvas.scaleFactor), camera.pixelWidth / canvas.scaleFactor);
        pos.y = Random.Range(-(camera.pixelHeight / canvas.scaleFactor), camera.pixelHeight / canvas.scaleFactor);
        pos = pos - (pos / 2);

        GameObject bolha = Instantiate(Resources.Load("bolhaUI"),pos, transform.rotation, canvas.transform) as GameObject;
        bolha.transform.localPosition = pos;

    }
}
