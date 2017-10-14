using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMission : MonoBehaviour {

    [SerializeField] private Mission mission;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            mission.ActiveMission();
    }
}
