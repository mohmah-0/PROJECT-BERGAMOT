using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerColor : MonoBehaviour
{
    [SerializeField] Material[] materials;
    public void SetColor()
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Player");



        foreach (GameObject car in cars)
        {
            int id = car.GetComponent<PlayerDetails>().playerID;
            int cartype = (car.name.StartsWith("CoolerRaceCar")) ? 1 : 0;
            car.GetComponent<PlayerDetails>().playerID = cartype;
            Debug.Log("biltyp: " + cartype);
            switch (id)
            {
                case 1:
                    car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cartype].color = Color.red;
                    break;
                case 2:
                    car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cartype].color = Color.blue;
                    break;
                case 3:
                    car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cartype].color = Color.yellow;
                    break;
                case 4:
                    car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[cartype].color = Color.green;
                    break;
            }
        }
    }
}
