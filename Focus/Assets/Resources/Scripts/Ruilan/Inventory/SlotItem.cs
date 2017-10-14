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

    public bool isActived;
    private float secDurationActivedCurent;

    private void Start()
    {
        IsEmpty = true;
        itemInSlot = null;
    }

    public Item ItemInSlot { get { return itemInSlot;} }

    public void ActivedItem()
    {
        if (!isActived)
        {
            isActived = true;
            secDurationActivedCurent = ItemInSlot.secDurationActived;
            InvokeRepeating("CountTimeActived", 0, 1f);
        }
    }

    private void CountTimeActived()
    {
        if (ItemInSlot.power == Power.ClearSmokeActived)
        {
            Debug.Log("Active: " + ItemInSlot.secDurationActived);
            --secDurationActivedCurent;
            if (secDurationActivedCurent <= 0)
            {
                Removed();
                CancelInvoke("CountTimeActived");
            }
        }
    } 

    public void Add(ref Item item)
    {
        icon.sprite = item.icon;
        itemInSlot = item;
        IsEmpty = false;
    }

    public void Removed()
    {
        icon.sprite = null;
        itemInSlot = null;
        IsEmpty = true;
    }
}
