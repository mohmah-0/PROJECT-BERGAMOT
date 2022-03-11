using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        for (int i = 0; i < 3; i++)
            Instantiate(car, spawnPoints[i]);    
    }
}
