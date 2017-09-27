using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Interactable {

    [SerializeField] private Item item;
    private Inventory inventory;

    // Use this for initialization
    void Awake () {
        inventory = FindObjectOfType<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();

        inventory.AddItem(item);
        Destroy(this.gameObject);
    }
}
