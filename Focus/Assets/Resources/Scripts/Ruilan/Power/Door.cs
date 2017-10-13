using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField] private Sprite closeSpr;
    [SerializeField] private Sprite openSpr;

    private bool isOpen;

    private void Open()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isOpen)
        {
            for (int i = 0; i < Inventory.instance.itemSlot.Length; i++)
            {
                if (!Inventory.instance.itemSlot[i].IsEmpty && Inventory.instance.itemSlot[i].ItemInSlot.power == Power.OpenDoor)
                {
                    GetComponent<SpriteRenderer>().sprite = openSpr;
                    Open();
                    break;
                }
            }

        }
    }
}
