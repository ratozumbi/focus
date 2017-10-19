using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemTimed: MonoBehaviour {

    [SerializeField] private Item item;
	
	private void Start()
	{
		Invoke("GetTheItem", 3);
	}

    public void GetTheItem()
    {
        Inventory.instance.AddItem(item);
        Destroy(this.gameObject);
    }
}
