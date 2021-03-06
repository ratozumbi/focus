﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
	[SerializeField] private GameObject imageEndGame;
	[SerializeField] private GameObject centro;

    [Space]
    [SerializeField] private GameObject imgAudicao;

    public static FinishGame instance;

    private void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int numEquipment = 0;
            for (int i = 0; i < Inventory.instance.equipmentsSlots.Length; i++)
            {
                if(Inventory.instance.equipmentsSlots[i].GetEquipment != null)
                {
                    ++numEquipment;
                }
            }
            if(numEquipment == Inventory.instance.equipmentsSlots.Length-1)
            {
                ResetScene();
            }
        }
    }

    public void ActiveFinishGameEffect()
    {
        int numEquipment = 0;
        for (int i = 0; i < Inventory.instance.equipmentsSlots.Length; i++)
        {
            if (Inventory.instance.equipmentsSlots[i].GetEquipment != null)
            {
                ++numEquipment;
            }
        }
        if (numEquipment == (Inventory.instance.equipmentsSlots.Length - 1))
        {
            centro.SetActive(false);
            imgAudicao.SetActive(true);
        }

    }

    private void ResetScene()
    {
		imageEndGame.SetActive(true);
        Invoke("LoadScene", 7f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
