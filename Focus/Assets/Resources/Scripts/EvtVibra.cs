using UnityEngine;
using System.Collections;

public class EvtVibra : MonoBehaviour {

	public GameObject player;
	public float timeWait = 1f;

	private float lastVibra = 0;
	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Player");
		GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.realtimeSinceStartup - lastVibra > timeWait) {

			lastVibra = Time.realtimeSinceStartup;

			if (Vector3.Distance (transform.position, player.transform.position) < 1) {
				Vibration.Vibrate (500);
				GetComponent<SpriteRenderer> ().enabled = true;
			} else if (Vector3.Distance (transform.position, player.transform.position) < 2) {
				Vibration.Vibrate (200);
				GetComponent<SpriteRenderer> ().enabled = false;
			} else if (Vector3.Distance (transform.position, player.transform.position) < 4) {
				Vibration.Vibrate (50);
				GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
	
	}
}
