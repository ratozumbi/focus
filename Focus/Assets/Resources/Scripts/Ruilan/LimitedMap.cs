using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedMap : MonoBehaviour {

    [SerializeField] private Transform spawnInitGame;

    private CameraController camera;

	// Use this for initialization
	void Awake () {
        camera = FindObjectOfType<CameraController>();

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = new Vector3(spawnInitGame.position.x, spawnInitGame.position.y, collision.transform.position.z);
            camera.ResetPosition();
        }
    }
}
