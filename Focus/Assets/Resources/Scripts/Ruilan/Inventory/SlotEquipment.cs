using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotEquipment : MonoBehaviour {

    public Image icon;

    private Equipment equipment;

    public Equipment GetEquipment { get { return equipment; } }

	public void Add (Equipment item)
    {
        equipment = item;
        icon.sprite = item.icon;
    }
    
}