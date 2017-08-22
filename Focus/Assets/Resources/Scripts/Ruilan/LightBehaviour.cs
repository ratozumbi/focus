using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBehaviour : MonoBehaviour {

	[SerializeField] private Transform focusPosition;
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
		Vector3 screen = camera0.WorldToScreenPoint(new Vector3(focusPosition.position.x, focusPosition.position.y));
		//topLight.position = new Vector3(focusPosition.transform.position.x, focusPosition.transform.position.y);
		topLight.position = new Vector3((focusPosition.transform.position.x*2 - (camera0.pixelWidth))/ 100, focusPosition.transform.position.y /80);
    }

    public void SizeLight()
    {
        light.localScale = new Vector3(scaleLightInit + ScoreManager.Score, light.localScale.y, light.localScale.z);
    }
}
