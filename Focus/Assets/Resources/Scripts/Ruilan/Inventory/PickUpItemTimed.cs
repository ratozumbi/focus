using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemTimed: MonoBehaviour {


    [SerializeField] private Item item;
	[SerializeField] private int TimeGoGrab = 2;

	private void Start()
	{
		Invoke("GetTheItem", TimeGoGrab);
	}

    public void GetTheItem()
    {
        Inventory.instance.AddItem(item);
        Destroy(this.gameObject);
    }
}
