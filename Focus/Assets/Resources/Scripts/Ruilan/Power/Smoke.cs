using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

    private Vector3 initPos;
    private Rigidbody2D rb;

    private Transform player;

    private bool collPlayer;

    // Use this for initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start () {
        initPos = GetComponent<Transform>().position;
        rb.gravityScale = 0f;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collPlayer = true;
            player = collider.gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            collPlayer = false;
    }

    private void FixedUpdate()
    {
        if (collPlayer) {
            for (int i = 0; i < Inventory.instance.itemSlot.Length; i++)
            {
                if (!Inventory.instance.itemSlot[i].IsEmpty && Inventory.instance.itemSlot[i].ItemInSlot.power == Power.ClearSmoke)
                {
                    float direction = (player.position - this.transform.position).normalized.y;
                    Debug.Log(direction);
                    transform.Translate(new Vector3(0, -direction) * Time.deltaTime);
                }
            }
        }
        else
        {
            float step = 1 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, initPos, step);
        }
    }
}
