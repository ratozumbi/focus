﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvtSomRuim : MonoBehaviour {

    public AudioSource mySom;

    public GameObject player;
    public float timeWait = 1f;


	public float distToAct = 4;

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
        int indexCurSlot = 0;
        for (int i = 0; i < Inventory.instance.itemSlot.Length; i++)
        {
            if (Inventory.instance.itemSlot[i].itemInSlot != null && Inventory.instance.itemSlot[i].itemInSlot.debuf == Debuf.Deaf)
            {
                isActiveDebuf = false;
                indexCurSlot = i;
                isActiveDebuf = true;
                mySom.mute = true;
                break;
            }
        }

        if (Time.realtimeSinceStartup - lastVibra > timeWait)
        {

            lastVibra = Time.realtimeSinceStartup;

			if (Vector3.Distance(transform.position, player.transform.position) < distToAct/3)
            {
                if (isActiveDebuf)
                    Inventory.instance.itemSlot[indexCurSlot].Removed();
                mySom.mute = false;
                //GetComponent<SpriteRenderer> ().enabled = true;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = true;
            }
			else if (Vector3.Distance(transform.position, player.transform.position) < distToAct/2 && !isActiveDebuf)
            {
                mySom.mute = false;
                //GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            }
			else if (Vector3.Distance(transform.position, player.transform.position) < distToAct && !isActiveDebuf)
            {
                mySom.mute = false;
                //GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            }
        }

    }
}
