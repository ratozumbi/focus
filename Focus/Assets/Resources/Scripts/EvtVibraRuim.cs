using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvtVibraRuim : MonoBehaviour {

    public GameObject player;
    public float timeWait = 1f;

	public float distToAct = 3;

    private float lastVibra = 0;

    private bool isActiveDebuf;
    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("Player");
        //GetComponent<SpriteRenderer> ().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - lastVibra > timeWait)
        {
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

            lastVibra = Time.realtimeSinceStartup;
			if (Vector3.Distance(transform.position, player.transform.position) < distToAct/3)
            {
                if (isActiveDebuf)
                    Inventory.instance.itemSlot[indexCurSlot].Removed();
                Vibration.Vibrate(1000);
                //GetComponent<SpriteRenderer> ().enabled = true;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = true;
            }
			else if (Vector3.Distance(transform.position, player.transform.position) < distToAct/2 && !isActiveDebuf)
            {
                Vibration.Vibrate(600);
                //GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            }
			else if (Vector3.Distance(transform.position, player.transform.position) < distToAct && !isActiveDebuf)
            {
                Vibration.Vibrate(50);
                //GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            }

        }

    }
}
