using UnityEngine;
using System.Collections;

public class EvtSom : MonoBehaviour {

	public AudioSource mySom;

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
				GetComponent<SpriteRenderer> ().enabled = true;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = true;
            } else if (Vector3.Distance (transform.position, player.transform.position) < 2) {
				GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            } else if (Vector3.Distance (transform.position, player.transform.position) < 4) {
				GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            }
		}

	}
}
