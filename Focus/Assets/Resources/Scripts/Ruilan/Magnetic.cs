using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private float forceGravity;
    [SerializeField]
    private float distance = 1.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

        if(Vector2.Distance(player.position, this.transform.position) < distance) {

            Vector2 direction = this.transform.position - player.position;
            direction = direction.normalized;
            player.Translate(direction * forceGravity, Space.World);
        }
    }

}
