using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
	[SerializeField] private GameObject image;
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
        Debug.Log(Inventory.instance.equipmentsSlots.Length);
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
            if(numEquipment == Inventory.instance.equipmentsSlots.Length)
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
        image.SetActive(true);
        Invoke("LoadScene", 3f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
