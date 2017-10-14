using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemTimed: MonoBehaviour {

    [SerializeField] private Item item;
    private Inventory inventory;

    // Use this for initialization
    void Awake () {
        inventory = FindObjectOfType<Inventory>();
    }
	
	private void Start()
	{
		Invoke("GetTheItem", 3);
	}

    public void GetTheItem()
    {

        inventory.AddItem(item);
        Destroy(this.gameObject);
    }
}
