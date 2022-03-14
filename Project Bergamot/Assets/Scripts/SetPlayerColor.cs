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
            int cartype = (car.name == "CoolerRaceCar(Clone)") ? 1 : 0;
            Debug.Log(id);
            switch (id)
            {
                case 1:
                    //Debug.Log(car.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[0]);
                    //FindObjectOfType<colllors>().colors[0].color = Color.black;
                    Debug.Log("biltyp: " + cartype);
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
