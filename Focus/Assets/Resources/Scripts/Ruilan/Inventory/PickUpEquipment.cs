using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEquipment : Interactable
{
    [SerializeField] private Equipment equipment;

    private Inventory inventory;

    private static Equipment auxEqui;

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

        auxEqui = Inventory.instance.GetEquipment(equipment.typeEquipment);

        inventory.AddEquipment(equipment);

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
