using UnityEngine;
using System.Collections;

public class FundoWebC : MonoBehaviour
{

	public Texture fundoOriginal;


	private WebCamDevice webDevice;
	private WebCamTexture webTexture;

	// Use this for initialization
	void Start ()
	{		
		WebCamDevice[] devices = WebCamTexture.devices;
		if(devices.Length != 0){
//			for (int i = 0; i < devices.Length; i++)
//			{
//				if (devices [i].isFrontFacing) {
//					webDevice = devices [i];
//					webTexture = new WebCamTexture (devices [i].name,1000,1000);
//					webTexture.Play ();
//					break;
//				}
//			}
//
			webTexture = new WebCamTexture ();
			webTexture.Play ();

			this.GetComponent<SpriteRenderer> ().material.mainTexture = webTexture;
		}
	}

	
	// Update is called once per frame
	void Update ()
	{

	}
}

