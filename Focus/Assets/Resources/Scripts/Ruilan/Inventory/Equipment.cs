using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : ScriptableObject
{
    public EquipmentSlot typeEquipment;
    public Sprite icon;

    public enum EquipmentSlot { Head, Chest, Leg }
}
