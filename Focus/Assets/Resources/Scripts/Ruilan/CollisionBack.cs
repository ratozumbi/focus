using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBack : MonoBehaviour {


    public bool playerTrigger;
    public Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (string.Compare(collision.gameObject.tag, "Player") == 0)
        {
            playerTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (string.Compare(collision.gameObject.tag, "Player") == 0)
        {
            playerTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (string.Compare(collision.gameObject.tag, "Player") == 0)
        {
            playerTrigger = false;
        }
    }
}
