using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private GameObject image;

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

            Debug.Log("Num Equipment: " + numEquipment + " " + Inventory.instance.equipmentsSlots.Length);
            if(numEquipment == (Inventory.instance.equipmentsSlots.Length))
            {
                ResetScene();
            }
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
