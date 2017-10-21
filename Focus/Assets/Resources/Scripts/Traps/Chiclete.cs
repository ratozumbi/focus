using UnityEngine;
using System.Collections;

public class Chiclete : MonoBehaviour
{
	[SerializeField] private int effectTime;
	[SerializeField] private GameObject player;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");

		player.GetComponent<PlayerMovement> ().walkSpeed -= 1; 

		Invoke("EndEffect", effectTime);
	}
		

	void  EndEffect()
	{
		player.GetComponent<PlayerMovement> ().walkSpeed += 1;
	}


	// Update is called once per frame
	void Update ()
	{
	
	}
}

