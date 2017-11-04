using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensagemTrap : MonoBehaviour {
	
	[SerializeField] private GameObject objTrap;
	[SerializeField] private GameObject player;

	[SerializeField] private int qtdToGen = 8;

	[SerializeField] private int radius = 4;

	[SerializeField] private int delay = 0;


	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		StartCoroutine(doGen());

	}

	IEnumerator doGen(){

		for (int i = 0; i < qtdToGen; i++) {

			Vector3 objPos;
			objPos = Random.insideUnitCircle * radius;

			objPos += player.transform.position;

			GameObject trap = Instantiate(objTrap, objPos, Quaternion.identity);

			yield return new WaitForSeconds(delay);

		}


		Destroy (this.gameObject);


	}


}
