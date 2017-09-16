using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFront : MonoBehaviour {

    [SerializeField] private Transform sprite;
    [SerializeField] private Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (string.Compare(collision.gameObject.tag, "Player") == 0)
        {
            sprite.position = new Vector3(sprite.position.x, sprite.position.y, 1);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (string.Compare(collision.gameObject.tag, "Player") == 0)
        {
            sprite.position = new Vector3(sprite.position.x, sprite.position.y, -7);
        }
    }
}
