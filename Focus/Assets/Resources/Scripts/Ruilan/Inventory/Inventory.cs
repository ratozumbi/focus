using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [SerializeField] private SpriteRenderer[] equipmentInGame;
    public SlotEquipment[] equipmentsSlots;

    public SlotItem[] itemSlot;

    public static Inventory instance;

    private void Start()
    {
        instance = this;
    }
    
    private void CountTimeActive()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].ItemInSlot.isActivatable)
            {
                --itemSlot[i].ItemInSlot.secDurationActived;
                if(itemSlot[i].ItemInSlot.secDurationActived <= 0)
                {
                    itemSlot[i].Removed();
                    CancelInvoke("CountTimeActive");
                }
            }
        }
    }

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

    public Equipment GetEquipment(Equipment.EquipmentSlot index)
    {
        return equipmentsSlots[(int)index].GetEquipment;
    }

    public void AddEquipment(Equipment equipment)
    {
        int indexSlot = (int)equipment.typeEquipment;

        equipmentsSlots[indexSlot].Add(equipment);
        equipmentInGame[indexSlot].sprite = equipment.spriteInGame;
    }
}
