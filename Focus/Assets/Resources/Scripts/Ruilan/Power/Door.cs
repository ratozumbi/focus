using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField] private Sprite closeSpr;
    [SerializeField] private Sprite openSpr;

    private bool isOpen;

    private void Open()
    {
		GetComponent<PolygonCollider2D> ().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Active Door");
        if (collision.gameObject.tag == "Player" && !isOpen)
        {
            for (int i = 0; i < Inventory.instance.itemSlot.Length; i++)
            {
                if (!Inventory.instance.itemSlot[i].IsEmpty && Inventory.instance.itemSlot[i].itemInSlot.power == Power.OpenDoor)
                {
					Inventory.instance.itemSlot [i].Removed ();
                    GetComponent<SpriteRenderer>().sprite = openSpr;
                    Open();
                    break;
                }
            }

        }
    }
}
