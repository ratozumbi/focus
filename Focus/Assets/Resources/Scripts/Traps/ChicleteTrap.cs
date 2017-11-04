using UnityEngine;
using System.Collections;

public class ChicleteTrap : MonoBehaviour
{

	[SerializeField] private GameObject player;
	[SerializeField] private GameObject chicleteTrap;

	private float walkSpeedOriginal;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		chicleteTrap = GameObject.Find ("chicletePlayer");

		walkSpeedOriginal = player.GetComponent<PlayerMovement> ().walkSpeed; 
		player.GetComponent<PlayerMovement> ().walkSpeed = 1;

		chicleteTrap.GetComponent<SpriteRenderer>().enabled = true;


		Invoke("EndEffect", 6);
	}
		

	void  EndEffect()
	{
		player.GetComponent<PlayerMovement> ().walkSpeed = walkSpeedOriginal;

		chicleteTrap.GetComponent<SpriteRenderer>().enabled = false;

	}


	// Update is called once per frame
	void Update ()
	{
	
	}
}

