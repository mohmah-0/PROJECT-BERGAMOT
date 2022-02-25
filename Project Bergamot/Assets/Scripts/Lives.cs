using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 3;
    
    public void OutOfView()
    {
        if (lives > 0)
        {
            lives--;
            GameObject leadCar = CrossChecking.cars[0].carObject.transform.GetChild(0).gameObject;
            transform.GetChild(0).transform.position = leadCar.transform.position;
        }
    }
}
