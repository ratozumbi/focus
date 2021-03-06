﻿using UnityEngine;
using System.Collections;

public class EvtSom : MonoBehaviour {

	public AudioSource mySom;

	public GameObject player;
	public float timeWait = 1f;

	private float lastVibra = 0;

	public float distToAct = 4;

    private bool isActiveDebuf;

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
				if (Inventory.instance.itemSlot[i].itemInSlot != null && Inventory.instance.itemSlot[i].itemInSlot.debuf == Debuf.Deaf)
                {
                    Debug.Log("Item Debuf: " + Inventory.instance.itemSlot[i].itemInSlot.debuf);
                    isActiveDebuf = false;
                    indexCurSlot = i;
                    isActiveDebuf = true;
                    mySom.mute = true;
                    break;
                }
            }

			if (Vector3.Distance (transform.position, player.transform.position) < distToAct/3) {
                if (isActiveDebuf)
                    Inventory.instance.itemSlot[indexCurSlot].Removed();
                mySom.mute = false;
                //GetComponent<SpriteRenderer> ().enabled = true;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = true;
			} else if (Vector3.Distance (transform.position, player.transform.position) < distToAct/2 && !isActiveDebuf) {
                mySom.mute = false;
                //GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
			} else if (Vector3.Distance (transform.position, player.transform.position) < distToAct && !isActiveDebuf) {
                mySom.mute = false;
                //GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            }
		}

	}
}
