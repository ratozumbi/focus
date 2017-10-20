using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{

    [SerializeField] Image icon;

    public bool IsEmpty { get; set; }

	public Item itemInSlot;

    public bool isActived;
    private float secDurationActivedCurent;

    private void Start()
    {
        IsEmpty = true;
        itemInSlot = null;
    }

    //public Item ItemInSlot { get { return itemInSlot;} } //tava retornando instancia nula

    public void ActivedItem()
    {
        if (!isActived)
        {
            isActived = true;
            secDurationActivedCurent = itemInSlot.secDurationActived;
            InvokeRepeating("CountTimeActived", 0, 1f);
        }
    }

    private void CountTimeActived()
    {
        if (itemInSlot.power == Power.ClearSmokeActived)
        {
            Debug.Log("Active: " + itemInSlot.secDurationActived);
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
