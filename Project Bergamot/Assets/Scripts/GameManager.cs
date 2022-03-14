using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameObject[] cars;


    // Start is called before the first frame update
    void Awake()
    {
        cars = GameObject.FindGameObjectsWithTag("Player");//maybe just use this directy from wherever it's useds
    }


}
