using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlant : MonoBehaviour {

    [SerializeField] private bool isGoodPlant;

    private bool activedpower;
    [SerializeField] private GameObject currentPlant;
    [SerializeField] private Transform parentInst;

    [SerializeField] private GameObject prefGoodPlant;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !activedpower)
        {
            for (int i = 0; i < Inventory.instance.itemSlot.Length; i++)
            {
                if (!Inventory.instance.itemSlot[i].IsEmpty && Inventory.instance.itemSlot[i].itemInSlot.power == Power.ChangePlant)
                {
                    activedpower = true;
                    Debug.Log("Power Change Plant");
                    int randNum = Random.Range(0, 100);
                    if(randNum > 50)
                    {
                        Debug.Log("Actived Change Power!!!");
                        Transform curPos = currentPlant.transform;
                        Destroy(currentPlant);
                        GameObject newPlant;
                        newPlant = Instantiate(prefGoodPlant, curPos.position, curPos.rotation, parentInst);
                    }
                    break;
                }
            }
        }
    }
}
