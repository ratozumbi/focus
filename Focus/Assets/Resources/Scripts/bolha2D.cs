using UnityEngine;
using System.Collections;

public class bolha2D : MonoBehaviour {
	public bool die = true;
	private GameObject player;
	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Vector3.Distance (transform.position, player.transform.position) < 1) {
			pega ();
		}
	}

	void pega(){
		BarraFocus bf = GameObject.Find ("qtdFoco").GetComponent<BarraFocus> ();
		bf.addValue (0.33f);

		if (die)
			Destroy (this.gameObject);
	}
}
