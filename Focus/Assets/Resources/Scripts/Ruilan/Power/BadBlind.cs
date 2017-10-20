using UnityEngine;
using System.Collections;

public class BadBlind : MonoBehaviour
{
	
	[SerializeField] GameObject wallDestroy;

	private Collider2D coll;

	private void Start()
	{
		coll = GetComponent<Collider2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			for (int i = 0; i < Inventory.instance.itemSlot.Length; i++)
			{
				if (!Inventory.instance.itemSlot[i].IsEmpty && Inventory.instance.itemSlot[i].itemInSlot.debuf == Debuf.Blind)
				{
					Destroy(wallDestroy);
					coll.enabled = false;
					break;
				}
			}

		}
	}
}

