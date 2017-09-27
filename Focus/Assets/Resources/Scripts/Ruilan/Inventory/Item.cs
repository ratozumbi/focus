using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite icon;
    public Power power;
    
}

public enum Power { Dig, Jump, FractureWalls, OpenDoor, ClearSmoke, ChangePlant}