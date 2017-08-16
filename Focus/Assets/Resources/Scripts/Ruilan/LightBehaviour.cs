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

    private float scaleLightInit;

    public int Score { get; private set; }

    public void AddPointer()
    {
        Score++;

        SizeLight();
    }
    
	// Use this for initialization
	void Start () {
        scaleLightInit = baseLight.localScale.x;
    }
	
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (focusPosition && playerPosition && baseLight && topLight)
        {
            baseLight.position = new Vector3(playerPosition.position.x, playerPosition.position.y -20);
            topLight.position = new Vector3(focusPosition.position.x, focusPosition.position.y);
        }
    }

    private void SizeLight()
    {
        baseLight.localScale = new Vector3(scaleLightInit + Score, baseLight.localScale.y);
    }
}
