using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraEquilibrio : MonoBehaviour {
	public Slider slide;
	//public UnityEngine.UI.Text txt;
	//public UnityEngine.UI.Dropdown dd;

	private float []medio = new float[12];
	private int count = 0;
	// Use this for initialization
	void Start () {

		slide = GetComponent<Slider> ();
		
	}
	
	// Update is called once per frame
	//12 ou int.Parse(dd.captionText.text)
	void Update () {
		if (count >= 12) {
			SetSlide ();
			count = 0;
		}

		medio[count] = Input.acceleration.x/2;
		count++;
	}

	void SetSlide(){
		float val = 0;
		for (int i = 0; i < 12; i++) {
			val += medio [i];
		}
//		if (int.Parse (dd.captionText.text) > 0) {
//			val = val / int.Parse (dd.captionText.text);
//		}
//		txt.text = "val = " + val;
		slide.value = val + 0.5f;
	}
}
