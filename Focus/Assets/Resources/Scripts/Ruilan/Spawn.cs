using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Spawn : MonoBehaviour
{

    [SerializeField] private Transform[] posSpwans;

    [SerializeField] private GameObject[] fileSpawn;

    [SerializeField] private int secSpawn;
    [SerializeField] private float velocityFiles;

    [SerializeField] private List<GameObject> filesSpawn;

    private void Start()
    {
        StartCoroutine(SpawnAsyc());
    }

    private void Update()
    {
        foreach (GameObject item in filesSpawn)
        {
            item.transform.Translate(Vector3.up * velocityFiles);
        }
    }

    IEnumerator SpawnAsyc()
    {
        while (true)
        {
            Instantiateparticle();
            yield return new WaitForSeconds(secSpawn);
        }
    }

    private void Instantiateparticle()
    {
        int iFile = Random.Range(0, fileSpawn.Length -1);
        int iPos = Random.Range(0, posSpwans.Length -1);

        filesSpawn.Add(Instantiate(fileSpawn[iFile], posSpwans[iPos]));
    }

}
