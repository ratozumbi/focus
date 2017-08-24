using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraEquilibrio : MonoBehaviour {
	public Slider slide;
    //public UnityEngine.UI.Text txt;
    //public UnityEngine.UI.Dropdown dd;

    public static int interactions = 6;

	private float []medio = new float[interactions];
	private int count = 0;
	// Use this for initialization
	void Start () {

		slide = GetComponent<Slider> ();
		
	}
	
	// Update is called once per frame
	//12 ou int.Parse(dd.captionText.text)
	void Update () {
		if (count >= interactions) {
			SetSlide ();
			count = 0;
		}

		medio[count] = Input.acceleration.x;
		count++;
	}

	void SetSlide(){
		float val = 0;
		for (int i = 0; i < interactions; i++) {
			val += medio [i];
		}
		val = val / interactions;

		slide.value = val + 0.5f;
	}
}
