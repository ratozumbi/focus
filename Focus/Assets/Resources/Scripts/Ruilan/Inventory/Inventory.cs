using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [SerializeField] private SpriteRenderer[] equipmentInGame;
    [SerializeField] private SlotEquipment[] equipmentsSlots;

    [SerializeField] public SlotItem[] itemSlot;

    public void AddItem(Item item)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].IsEmpty)
            {
                itemSlot[i].Add(ref item);
                break;
            }
        }
    }

    public void AddEquipment(Equipment equipment)
    {
        int indexSlot = (int)equipment.typeEquipment;

        equipmentsSlots[indexSlot].Add(equipment);
        equipmentInGame[indexSlot].sprite = equipment.spriteInGame;
    }
}
