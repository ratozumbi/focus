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
    
	// Use this for initialization
	void Start () {
        //InvokeRepeating("UpdatePosition", 2, 0.1f);
	}
	
    private void Update()
    {
        if (focusPosition && playerPosition && baseLight && topLight)
        {
            baseLight.position = new Vector3(playerPosition.position.x, baseLight.position.y);
            topLight.position = new Vector3(focusPosition.position.x, topLight.position.y);

        }
    }
}
