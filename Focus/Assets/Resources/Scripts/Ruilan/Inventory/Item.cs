﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite icon;
	public Power power;
	public Debuf debuf;
    public float secDurationActived;
}

public enum Power { Dig, Jump, FractureWalls, OpenDoor, ClearSmoke, ChangePlant, ClearSmokeActived, None }
public enum Debuf { None, Blind, Deaf, Unsensible }