using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{

    [SerializeField] Image icon;

    public bool IsEmpty { get; set; }

    private Item itemInSlot;

    private void Start()
    {
        IsEmpty = true;
        itemInSlot = null;
    }

    public void Add(ref Item item)
    {
        icon.sprite = item.icon;
        itemInSlot = item;
        IsEmpty = false;
    }
}
