using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarraFocus : MonoBehaviour
{
	public Slider slide;
	private GameObject chess;
	private GameObject mask;

	// Use this for initialization
	void Start ()
	{
		slide = GetComponent<Slider> ();
		chess = GameObject.Find ("chess");
		mask = GameObject.Find ("Mask");

	}

	public void removeValue(float val){
		slide.value -= val;
		setMasks ();
	}
	public void addValue(float val){
		slide.value += val;
		setMasks ();
	}

	private void setMasks(){

        RawImage cImg = chess.GetComponent<RawImage> ();
		Image mImg = mask.GetComponent<Image> ();

		float alpha;

		if (slide.value < 5.0f && slide.value != 0) {
			alpha = (1*slide.value)/5;
			alpha = 1 - alpha ;
			cImg.enabled = true;
			cImg.CrossFadeAlpha (alpha, 0, true);
		}
		if (slide.value > 5.0f) {
			cImg.enabled = false;
			alpha = (1*slide.value)/95;
			alpha = 1 - alpha ;
			mImg.CrossFadeAlpha (alpha, 0, true);
		}



	}

}

