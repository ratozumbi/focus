using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem: Interactable {

    [SerializeField] private Item item;

    // Use this for initialization
    void Awake () {
        //inventory = FindObjectOfType<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();

        Inventory.instance.AddItem(item);
        Destroy(gameObject);
    }
}
