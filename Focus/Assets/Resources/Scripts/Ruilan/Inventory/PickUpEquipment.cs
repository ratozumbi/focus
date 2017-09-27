using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEquipment : Interactable
{
    [SerializeField] private Equipment equipment;

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

        inventory.AddEquipment(equipment);
    }
}
