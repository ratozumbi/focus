using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    [SerializeField] private Hole holeLink;

    private Transform posHoleLink;
    new private Collider2D collider;

    public bool IsExitHole { get; set; }

    private void Awake()
    {
        posHoleLink = holeLink.transform;
        collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        posHoleLink.position = new Vector3(posHoleLink.position.x, posHoleLink.position.y, -0.83f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !IsExitHole)
        {
            for (int i = 0; i < Inventory.instance.itemSlot.Length; i++)
            {
                if(!Inventory.instance.itemSlot[i].IsEmpty && Inventory.instance.itemSlot[i].itemInSlot.power == Power.Dig)
                {
                    holeLink.IsExitHole = true;
                    collision.gameObject.transform.position = posHoleLink.position;
                    break;
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && IsExitHole)
        {
            IsExitHole = false;
        }
    }

    private void OnDrawGizmos()
    {
        posHoleLink = holeLink.transform;
        Gizmos.DrawLine(this.transform.position, posHoleLink.position);
    }
}
