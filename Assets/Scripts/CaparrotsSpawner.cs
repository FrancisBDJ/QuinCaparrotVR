using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CaparrotsSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] caparrotsPrefabs = new GameObject[11];
    
    private float xMin = -4.5f;
    private float xMax = 9.15f;
    private float zMin = -2f;
    private float zMax = 2f;
    private float yDefault = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnAllCaparrots();
    }

    private void SpawnAllCaparrots()
    {
        foreach (var caparrot in caparrotsPrefabs)
        {
            float xOffset = Random.Range(xMin, xMax);
            float zOffset = Random.Range(zMin, zMax);
            
            Vector3 offset = new Vector3(xOffset, yDefault, zOffset);
            
            Instantiate(caparrot, offset, Quaternion.identity);
        } 
    }
}
