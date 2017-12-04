using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBehaviour : MonoBehaviour {

	[SerializeField] private GameObject focusPosition;
	[SerializeField] private GameObject webcamBackground;
	[SerializeField] private Transform playerPosition;

	[SerializeField] private Camera camera0;

	[Space]
	[SerializeField] private Transform circle;
	[SerializeField] private Transform baseLight;
    [SerializeField] private Transform topLight;

    [Space]
    [SerializeField] private Transform light;

	private bool inOpenLight = true;
	private int lightState = 0;

	private Vector3 resultL = new Vector3();
	private Vector3 resultR = new Vector3();
	private Vector3 resultCirc = new Vector3();

    private float scaleLightInit;
    
	// Use this for initialization
	void Start () {
        scaleLightInit = light.localScale.y;
		circle = GameObject.Find("LuzCircle").GetComponent<Transform>();
    }
	
    private void Update()
    {
        Move();
		if(inOpenLight)
		{

			GameObject baseL = GameObject.Find("base.L");
			GameObject baseR = GameObject.Find("base.R");

			baseL.transform.position = Vector3.Lerp (baseL.transform.position, resultL, Time.deltaTime * 1);
			baseR.transform.position = Vector3.Lerp (baseR.transform.position, resultR, Time.deltaTime * 1);

			//circle.transform.localScale = Vector3.Lerp(circle.transform.localScale , resultCirc, Time.deltaTime * 1); 
		}
    }

    private void Move()
    {
        baseLight.position = new Vector3(playerPosition.position.x, playerPosition.position.y -0.8f - ScoreManager.Score / 10);
        //Get the location of the UI element you want the 3d onject to move towards
        Vector3 screenPoint = focusPosition.transform.position;

        //find out where this is in world space
        Vector3 worldPos = camera0.ScreenToWorldPoint(screenPoint);
        
        worldPos.z = 0;
        //move towards the world space position
        topLight.position = Vector3.MoveTowards(topLight.position, worldPos, 1);
    }

	public void SizeLight()
	{

		GameObject baseL = GameObject.Find("base.L");
		GameObject baseR = GameObject.Find("base.R");

		if (baseL.transform.localPosition.x - ScoreManager.Score / 10 < 4.0f && baseR.transform.localPosition.x + ScoreManager.Score / 10 > -4.0f) {
			resultL = new Vector3 (baseL.transform.position.x - lightState, baseL.transform.position.y, baseL.transform.position.z);
			resultR = new Vector3 (baseR.transform.position.x + lightState, baseR.transform.position.y, baseR.transform.position.z);
			resultCirc = new Vector3 (baseL.transform.position.x * lightState *100, 1, baseL.transform.position.x * lightState * 100); 
		}

		if (ScoreManager.Score > 4.0f) {
			lightState = 4;
		} else if (ScoreManager.Score > 3.0f) {
			lightState = 3;
		} else if (ScoreManager.Score > 2.0f) {
			lightState = 2;
		} else if (ScoreManager.Score > 1.0f) {
			lightState = 1;
		}

	}


//    public void SizeLight()
//    {
//        //light.localScale = new Vector3(light.localScale.x, light.localScale.y + ScoreManager.Score, light.localScale.z);
//        //baseLight.transform.position = new Vector3(baseLight.transform.position.x, baseLight.transform.position.y - ScoreManager.Score/100, baseLight.transform.position.z);
//
//        GameObject baseL = GameObject.Find("base.L");
//		GameObject baseR = GameObject.Find("base.R");
//
//
////		if (ScoreManager.Score / 10 > 4) {
////			webcamBackground.SetActive (false);
////		} else {
////			webcamBackground.SetActive (true);
////		}
//
//
//
//        if (baseL.transform.localPosition.x - ScoreManager.Score / 10 < 4.0f && baseR.transform.localPosition.x + ScoreManager.Score / 10 > -4.0f)
//        {
//            baseL.transform.position = new Vector3(baseL.transform.position.x - ScoreManager.Score / 10, baseL.transform.position.y, baseL.transform.position.z);
//            baseR.transform.position = new Vector3(baseR.transform.position.x + ScoreManager.Score / 10, baseR.transform.position.y, baseR.transform.position.z);            
//        }
//
//        if (baseL.transform.localPosition.x > 4.0f && baseR.transform.localPosition.x < -4.0f)
//        {
//            baseL.transform.position = new Vector3(playerPosition.position.x - 3.9f, baseL.transform.position.y, baseL.transform.position.z);
//            baseR.transform.position = new Vector3(playerPosition.position.x + 3.9f, baseR.transform.position.y, baseR.transform.position.z);
//        }
//
//        if (baseL.transform.localPosition.x < 0 && baseR.transform.localPosition.x > 0)
//        {
//            baseL.transform.position = new Vector3(playerPosition.position.x, baseL.transform.position.y, baseL.transform.position.z);
//            baseR.transform.position = new Vector3(playerPosition.position.x, baseR.transform.position.y, baseR.transform.position.z);
//        }
//
//
//		circle.transform.localScale = new Vector3 (baseL.transform.position.x * 100, 1, baseL.transform.position.x * 100); 
//
//    }
}
