using UnityEngine;
using System.Collections;

public class Chiclete : MonoBehaviour
{
	[SerializeField] private int effectTime = 3;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject chicleteTrap;


	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		chicleteTrap = GameObject.Find ("chicleteTrap");

		player.GetComponent<PlayerMovement> ().walkSpeed -= 3; 

		chicleteTrap.SetActive (true);


		Invoke("EndEffect", effectTime);
	}
		

	void  EndEffect()
	{
		player.GetComponent<PlayerMovement> ().walkSpeed += 3;

		chicleteTrap.SetActive (false);
	}


	// Update is called once per frame
	void Update ()
	{
	
	}
}

