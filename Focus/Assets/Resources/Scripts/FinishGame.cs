﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int numEquipment = 0;
            for (int i = 0; i < Inventory.instance.equipmentsSlots.Length; i++)
            {
                if(Inventory.instance.equipmentsSlots[i].GetEquipment != null)
                {
                    ++numEquipment;
                }
            }
            if(numEquipment == (Inventory.instance.equipmentsSlots.Length - 1))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}