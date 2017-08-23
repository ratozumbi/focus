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
        scaleLightInit = light.localScale.x;
    }
	
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        baseLight.position = new Vector3(playerPosition.position.x, playerPosition.position.y - 0.8f);
        //Get the location of the UI element you want the 3d onject to move towards
        Vector3 screenPoint = focusPosition.transform.position;// + new Vector3(0, 0, 500);  //the "+ new Vector3(0,0,5)" ensures that the object is so close to the camera you dont see it

        //find out where this is in world space
        Vector3 worldPos = camera0.ScreenToWorldPoint(screenPoint);
        
        worldPos.z = 0;
        //move towards the world space position
        topLight.position = Vector3.MoveTowards(topLight.position, worldPos, 1);
    }

    public void SizeLight()
    {
        light.localScale = new Vector3(scaleLightInit + ScoreManager.Score, light.localScale.y, light.localScale.z);
    }
}
