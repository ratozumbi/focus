using UnityEngine;
using System.Collections;

public class EvtLuzRuim : MonoBehaviour {


	private GameObject player;
	public float timeWait = 1f;


	private int luzCnt = 0;
	private float lastVibra = 0;

	public float distToAct = 3;

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
                if (Inventory.instance.itemSlot[i].itemInSlot != null && Inventory.instance.itemSlot[i].itemInSlot.debuf == Debuf.Blind)
                {
                    isActiveDebuf = false;
                    indexCurSlot = i;
                    break;
                }
                else
                    isActiveDebuf = true;
            }

			if (Vector3.Distance (transform.position, player.transform.position) < distToAct/3) {
                if (isActiveDebuf)
                    Inventory.instance.itemSlot[indexCurSlot].Removed();

                Vector2 pos = player.transform.position;
				Vector2 circ;
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho1 =  CriaLuz ();
				Destroy (brilho1, 0.5f);
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho2 =  CriaLuz ();
				Destroy (brilho2, 0.5f);
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho3 =  CriaLuz (); 
				Destroy (brilho3, 0.5f);
				GetComponent<SpriteRenderer> ().enabled = true;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = true;
			} else if (Vector3.Distance (transform.position, player.transform.position) < distToAct/2 && !isActiveDebuf) {
				Vector2 pos = player.transform.position;
				Vector2 circ;
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho1 =  CriaLuz ();
				Destroy (brilho1, 0.3f);
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho2 = CriaLuz ();
				Destroy (brilho2, 0.3f);
				//GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
			} else if (Vector3.Distance (transform.position, player.transform.position) < distToAct && !isActiveDebuf) {
				Vector2 pos = player.transform.position;
				Vector2 circ;
				circ = Random.insideUnitCircle;
				pos = pos + circ;
				GameObject brilho1 = CriaLuz ();
				Destroy (brilho1, 0.1f);
				//GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            }
		}

	}

	GameObject CriaLuz(){
		string brilhoBom = "brilhoBom";
		string brilhoRuim = "brilhoRuim";
		string brilho = "brilhoBom";

		luzCnt++;
		if (luzCnt == 3) {
			brilho = brilhoRuim;
			luzCnt = 0;
		} else {
			brilho = brilhoBom;
		}

		Vector2 pos = player.transform.position;
		Vector2 circ;
		circ = Random.insideUnitCircle;
		pos = pos + circ;

		return Instantiate(Resources.Load(brilho),pos, player.transform.rotation) as GameObject;
	}
}
