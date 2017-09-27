using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotEquipment : MonoBehaviour {

    [SerializeField] private Image icon;


	public void Add (Equipment item)
    {
        icon.sprite = item.icon;
    }
    
}