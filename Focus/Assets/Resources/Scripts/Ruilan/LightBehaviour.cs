using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBehaviour : MonoBehaviour {

	[SerializeField] private GameObject focusPosition;
	[SerializeField] private Transform playerPosition;

	[SerializeField] private Camera camera0;

    [Space]
    [SerializeField] private Transform baseLight;
    [SerializeField] private Transform topLight;

    [Space]
    [SerializeField] private Transform light;

    private float scaleLightInit;
    
	// Use this for initialization
	void Start () {
        scaleLightInit = light.localScale.y;
    }
	
    private void Update()
    {
        Move();
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
        //light.localScale = new Vector3(light.localScale.x, light.localScale.y + ScoreManager.Score, light.localScale.z);
        //baseLight.transform.position = new Vector3(baseLight.transform.position.x, baseLight.transform.position.y - ScoreManager.Score/100, baseLight.transform.position.z);

        GameObject baseL = GameObject.Find("base.L");
        GameObject baseR = GameObject.Find("base.R");


        if (baseL.transform.localPosition.x - ScoreManager.Score / 10 < 4.0f && baseR.transform.localPosition.x + ScoreManager.Score / 10 > -4.0f)
        {
            baseL.transform.position = new Vector3(baseL.transform.position.x - ScoreManager.Score / 10, baseL.transform.position.y, baseL.transform.position.z);
            baseR.transform.position = new Vector3(baseR.transform.position.x + ScoreManager.Score / 10, baseR.transform.position.y, baseR.transform.position.z);
            
        }

        if (baseL.transform.localPosition.x > 4.0f && baseR.transform.localPosition.x < -4.0f)
        {
            baseL.transform.position = new Vector3(playerPosition.position.x - 3.9f, baseL.transform.position.y, baseL.transform.position.z);
            baseR.transform.position = new Vector3(playerPosition.position.x + 3.9f, baseR.transform.position.y, baseR.transform.position.z);
        }

        if (baseL.transform.localPosition.x < 0 && baseR.transform.localPosition.x > 0)
        {
            baseL.transform.position = new Vector3(playerPosition.position.x, baseL.transform.position.y, baseL.transform.position.z);
            baseR.transform.position = new Vector3(playerPosition.position.x, baseR.transform.position.y, baseR.transform.position.z);
        }

    }
}
