using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBehaviour : MonoBehaviour {

    [SerializeField] private Transform focusPosition;
    [SerializeField] private Transform playerPosition;

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
        topLight.position = new Vector3(focusPosition.position.x, focusPosition.position.y);
    }

    public void SizeLight()
    {
        light.localScale = new Vector3(scaleLightInit + ScoreManager.Score, light.localScale.y, light.localScale.z);
    }
}
