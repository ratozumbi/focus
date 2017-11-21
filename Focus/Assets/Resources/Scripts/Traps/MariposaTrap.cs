using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariposaTrap : MonoBehaviour {
	
	public float speed = 1;
	private Transform destin;

	public float valToSub = 2;

	// Use this for initialization
	void Start () {
		destin = GameObject.Find ("FocusPhysics").GetComponent<Transform>();

	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log ("colide");
		if (collision.gameObject.name == (destin.gameObject.name)) {
			ScoreManager.SubPointer (valToSub);
			Destroy (this.gameObject);
		}

	}

	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;

		transform.position = Vector3.MoveTowards(transform.position, destin.position, step);
	}
}
