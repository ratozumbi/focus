using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [SerializeField] private SlotEquipment[] equipmentsSlots;

    public void AddEquipment(Equipment equipment)
    {
        int indexSlot = (int)equipment.typeEquipment;
        equipmentsSlots[indexSlot].Add(equipment);
    }
}
