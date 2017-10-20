using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvtSomRuim : MonoBehaviour {

    public AudioSource mySom;

    public GameObject player;
    public float timeWait = 1f;

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

            if (Vector3.Distance(transform.position, player.transform.position) < 1)
            {
                if (isActiveDebuf)
                    Inventory.instance.itemSlot[indexCurSlot].Removed();
                //GetComponent<SpriteRenderer> ().enabled = true;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = true;
            }
            else if (Vector3.Distance(transform.position, player.transform.position) < 2 && !isActiveDebuf)
            {
                //GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            }
            else if (Vector3.Distance(transform.position, player.transform.position) < 4 && !isActiveDebuf)
            {
                //GetComponent<SpriteRenderer> ().enabled = false;
                SpawnOne spawn = GetComponent<SpawnOne>();
                spawn.enabled = false;
            }
        }

    }
}
