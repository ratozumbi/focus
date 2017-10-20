using UnityEngine;
using System.Collections;

public class EvtLuz : MonoBehaviour {

	private GameObject player;
	public float timeWait = 1f;

	private float lastVibra = 0;

    public bool isActiveDebuf;
    // Use this for initialization
    void Start () {

		player = GameObject.Find ("Player");
		//GetComponent<SpriteRenderer> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {

		if (Time.realtimeSinceStartup - lastVibra > timeWait) {

			lastVibra = Time.realtimeSinceStartup;

            int indexCurSlot = 0;
            for (int i = 0; i < Inventory.instance.itemSlot.Length; i++)
            {
                if (!Inventory.instance.itemSlot[i].IsEmpty && Inventory.instance.itemSlot[i].itemInSlot.debuf == Debuf.Unsensible)
                {
                    isActiveDebuf = false;
                    indexCurSlot = i;
                    break;
                }
                else
                    isActiveDebuf = true;
            }

            if (Vector3.Distance (transform.position, player.transform.position) < 1) {
                if (isActiveDebuf)
                    Inventory.instance.itemSlot[indexCurSlot].Removed();

                Vector2 pos = player.transform.position;
				Vector2 circ;
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho1 = Instantiate(Resources.Load("brilhoBom"),pos, player.transform.rotation) as GameObject;
				Destroy (brilho1, 0.5f);
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho2 = Instantiate(Resources.Load("brilhoBom"),pos, player.transform.rotation) as GameObject;
				Destroy (brilho2, 0.5f);
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho3 = Instantiate(Resources.Load("brilhoBom"),pos, player.transform.rotation) as GameObject;
				Destroy (brilho3, 0.5f);
				//GetComponent<SpriteRenderer> ().enabled = true;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = true;
            } else if (Vector3.Distance (transform.position, player.transform.position) < 2 && !isActiveDebuf) {
				Vector2 pos = player.transform.position;
				Vector2 circ;
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho1 = Instantiate(Resources.Load("brilhoBom"),pos, player.transform.rotation) as GameObject;
				Destroy (brilho1, 0.3f);
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho2 = Instantiate(Resources.Load("brilhoBom"),pos, player.transform.rotation) as GameObject;
				Destroy (brilho2, 0.3f);
				//GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            } else if (Vector3.Distance (transform.position, player.transform.position) < 4 && !isActiveDebuf) {
				Vector2 pos = player.transform.position;
				Vector2 circ;
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho1 = Instantiate(Resources.Load("brilhoBom"),pos, player.transform.rotation) as GameObject;
				Destroy (brilho1, 0.1f);
				//GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            }
		}

	}
}
