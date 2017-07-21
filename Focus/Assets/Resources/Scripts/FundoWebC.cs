using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class FundoWebC : MonoBehaviour
{

	public Texture fundoOriginal;


	private RawImage raw;

	// Use this for initialization
	void Start ()
	{		        
		raw = GetComponent<RawImage> ();
		WebCamTexture webcamTexture = new WebCamTexture();

		if (WebCamTexture.devices.Length > 0 && raw !=null) {
			raw.texture = webcamTexture;
			//raw.material.mainTexture = webcamTexture;
			webcamTexture.Play ();
		}
	}

	
	// Update is called once per frame
	void Update ()
	{

	}
}

