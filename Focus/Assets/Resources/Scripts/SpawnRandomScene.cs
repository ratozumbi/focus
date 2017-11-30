using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomScene : MonoBehaviour {

    [SerializeField] private HouseSpawn[] spawnHouse;
    [Space]
    [SerializeField] private PlantsSpawn[] spawnPlants;

    private void Awake()
    {
        SpawnHouse();
        SpawnPlants();
    }

    private void SpawnHouse()
    {
        int indexRandom;

        for (int i = 0; i < spawnHouse.Length; i++)
        {
            indexRandom = Random.Range(0, spawnHouse[i].house.Length - 1);
            GameObject houseObj = Instantiate(spawnHouse[i].house[indexRandom], spawnHouse[i].pos);

            int itemIndex = Random.Range(0, spawnHouse[i].item.Length - 1);

            for (int x = 0; x < houseObj.GetComponent<Mission>().missions.Length; x++)
            {
                houseObj.GetComponent<Mission>().missions[x].itemDrop = spawnHouse[i].item[itemIndex];
            }
            
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
public class HouseSpawn
{
    public Transform pos;
    public GameObject[] house;
    public GameObject[] item;
}

[System.Serializable]
public class PlantsSpawn
{
    public Transform[] pos;
    public GameObject[] plants;
}
