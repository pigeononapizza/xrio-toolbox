using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SimpleSpawner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] Transform spawnPoint;

    void Awake()
    {
        spawnPoint = spawnPoint != null ? spawnPoint : this.transform;
    }
    public void SpawnObject()
    {
        Instantiate(objectToSpawn, spawnPoint);
    }
}

