using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject Racecar;
    public GameObject Coolcar;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        List<int> players = FindObjectOfType<PodiumPlacements>().players;
        List<int> cars = FindObjectOfType<PodiumPlacements>().carType;
        for (int i = 0; i < players.Count; i++)
        {
            if (cars[i] == 0)
            {
                GameObject car = Instantiate(Racecar, spawnPoints[i]);

                switch (players[i])
                {
                    case 1:
                        car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.red;
                        break;
                    case 2:
                        car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.blue;
                        break;
                    case 3:
                        car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.yellow;
                        break;
                    case 4:
                        car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.green;
                        break;
                }
            }

            if (cars[i] == 1)
            {
                GameObject car = Instantiate(Coolcar, spawnPoints[i]);

                switch (players[i])
                {
                    case 1:
                        car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.red;
                        break;
                    case 2:
                        car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.blue;
                        break;
                    case 3:
                        car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.yellow;
                        break;
                    case 4:
                        car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cars[i]].color = Color.green;
                        break;
                }
            }
        }
    }
}
