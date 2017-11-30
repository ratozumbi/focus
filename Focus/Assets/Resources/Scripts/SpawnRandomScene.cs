using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomScene : MonoBehaviour {

    [SerializeField] private Transform[] posHouse;
    [SerializeField] private GameObject[] objHouse;
    [SerializeField] private GameObject[] objItem;
    [Space]
    [SerializeField] private PlantsSpawn[] spawnPlants;

    private void Awake()
    {
        SpawnHouse();
        SpawnPlants();
    }

    private void SpawnHouse()
    {
        int indexHouse = Random.Range(0, objHouse.Length -1);
        for (int i = 0; i < posHouse.Length; i++)
        {
            GameObject house = Instantiate(objHouse[indexHouse], posHouse[i]);

            indexHouse = (indexHouse == objHouse.Length - 1) ? 0 : ++indexHouse;

            DescriptionMission[] mission = house.GetComponent<Mission>().missions;
            int ranItemIndex;

            for (int x = 0; x < mission.Length; x++)
            {
                ranItemIndex = Random.Range(0, objItem.Length - 1);
                mission[x].itemDrop = objItem[ranItemIndex];
            }

            house.GetComponent<Mission>().missions = mission;
        }
    }

    private void SpawnPlants()
    {
        for (int i = 0; i < spawnPlants.Length; i++)
        {
            int randomPos = Random.Range(0, spawnPlants[i].pos.Length - 1);
            int randomPlant = Random.Range(0, spawnPlants[i].plants.Length - 1);

            for (int x = 0; x < spawnPlants[i].pos.Length; x++)
            {
                Instantiate(spawnPlants[i].plants[randomPlant], spawnPlants[i].pos[randomPos]);

                if (randomPlant == spawnPlants[i].plants.Length - 1)
                    randomPlant = 0;
                else
                    randomPlant++;

                if (randomPos == spawnPlants[i].pos.Length - 1)
                    randomPos = 0;
                else
                    randomPos++;
            }
        }
    }
}

[System.Serializable]
public class PlantsSpawn
{
    public Transform[] pos;
    public GameObject[] plants;
}
