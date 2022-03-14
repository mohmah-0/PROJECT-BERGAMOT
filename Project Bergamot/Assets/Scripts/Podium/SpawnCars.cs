using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] cars;

    // Start is called before the first frame update
    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject car in cars)
        {
            car.GetComponentInChildren<Rigidbody>().isKinematic = true;
        }
        Spawn();
    }

    void Spawn()
    {
        //List<int> players = FindObjectOfType<PodiumPlacements>().players;
        //List<int> cars = FindObjectOfType<PodiumPlacements>().carType;
        GameObject[] activeItems = GameObject.FindGameObjectsWithTag("items");
        foreach( GameObject item in activeItems)
        {
            item.gameObject.SetActive(false);
        }

        for (int i = 0; i < cars.Length; i++)
        {
            Debug.Log(cars[i].name);
            cars[i].transform.position = spawnPoints[i].transform.position;
            cars[i].transform.rotation = spawnPoints[i].transform.rotation;
            cars[i].transform.GetChild(0).position = spawnPoints[i].transform.position;
            cars[i].transform.GetChild(0).rotation = spawnPoints[i].transform.rotation;
            Debug.Log("  kkkkk " + cars[i].transform.position + "  rigids: " + cars[i].transform.GetChild(0).GetComponent<Rigidbody>().position);

            //if (cars[i] == 0)
            //{
            //    GameObject car = Instantiate(Racecar, spawnPoints[i]);

            //    switch (players[i])
            //    {
            //        case 1:
            //            car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.red;
            //            break;
            //        case 2:
            //            car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.blue;
            //            break;
            //        case 3:
            //            car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.yellow;
            //            break;
            //        case 4:
            //            car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.green;
            //            break;
            //    }
            //}

            //if (cars[i] == 1)
            //{
            //    GameObject car = Instantiate(Coolcar, spawnPoints[i]);

            //    switch (players[i])
            //    {
            //        case 1:
            //            car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.red;
            //            break;
            //        case 2:
            //            car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.blue;
            //            break;
            //        case 3:
            //            car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.yellow;
            //            break;
            //        case 4:
            //            car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.green;
            //            break;
            //    }
            //}
        }
    }
}
