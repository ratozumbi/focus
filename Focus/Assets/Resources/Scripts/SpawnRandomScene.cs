using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomScene : MonoBehaviour {

    [SerializeField] private Transform[] posMissionsHouse;
    [SerializeField] private GameObject[] objMissionsHouse;
    [Space]
    [SerializeField] private Transform[] posPlants1;
    [SerializeField] private GameObject[] objPlants1;
    [Space]
    [SerializeField] private Transform[] posPlants2;
    [SerializeField] private GameObject[] objPlants2;
    [Space]
    [SerializeField] private Transform[] posPlants3;
    [SerializeField] private GameObject[] objPlants3;

    private void Awake()
    {
        SpawnHouse();
    }

    private void SpawnHouse()
    {
        int ranIndex = Random.Range(0, objMissionsHouse.Length - 1);
        for (int i = 0; i < posMissionsHouse.Length; i++)
        {
            Instantiate(objMissionsHouse[ranIndex], posMissionsHouse[i]);
            if (ranIndex == objMissionsHouse.Length - 1)
                ranIndex = 0;
            else
                ranIndex++;
        }
    }

    private void SpawnPlants()
    {

    }
}
