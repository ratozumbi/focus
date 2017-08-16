using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class FundoWeb2D : MonoBehaviour
{

	public Texture fundoOriginal;


	private SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
	{		        
		sprite = GetComponent<SpriteRenderer> ();
		WebCamTexture webcamTexture = new WebCamTexture();

		if (WebCamTexture.devices.Length > 0 && sprite !=null) {
			webcamTexture.Play ();
            sprite.sprite = Sprite.Create(webcamTexture.GetPixels(), transform, Vector2.zero);
        }
	}

	
	// Update is called once per frame
	void Update ()
	{

	}
}

