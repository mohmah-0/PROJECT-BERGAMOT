using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    GameObject[] cars;
    public List<GameObject> playerPrefab = new List<GameObject>();

    private void Awake()
    {
        GameObject[] tempPlayerList = GameObject.FindGameObjectsWithTag("GameController");

        for(int i = 0; i < tempPlayerList.Length; i++)
        {
            GameObject temp = Instantiate<GameObject>(playerPrefab[0]);/*
            temp.AddComponent
            temp.GetComponent<PlayerInput>() = tempPlayerList[i].GetComponent<PlayerInput>();*/
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
