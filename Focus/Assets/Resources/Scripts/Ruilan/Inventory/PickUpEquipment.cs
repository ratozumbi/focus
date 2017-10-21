using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEquipment : Interactable
{
    [SerializeField] private Equipment equipment;

    private static Equipment auxEqui;
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();

        auxEqui = Inventory.instance.GetEquipment(equipment.typeEquipment);

        Inventory.instance.AddEquipment(equipment);

        ChangeEquipment();

        equipment = auxEqui;
    }

    private void ChangeEquipment()
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();

        if (auxEqui != null)
        {
            GetComponent<SpriteRenderer>().sprite = auxEqui.icon;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
