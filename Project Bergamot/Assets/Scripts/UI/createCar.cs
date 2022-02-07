using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Create Car")]
public class createCar : ScriptableObject
{
    public Sprite carImage;
    public string carText;

    public void printCar()
    {
        Debug.Log("Car text: " + carText);
    }
}
