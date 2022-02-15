using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] cars;
    // Start is called before the first frame update
    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cars = GameObject.FindGameObjectsWithTag("Player");
    }

    public GameObject getLeadCar()
    {

        try
        {
            return cars[0];
        }catch(Exception e)
        {
            Debug.Log("Inga bilar");
            return null;
        }
    }
}
