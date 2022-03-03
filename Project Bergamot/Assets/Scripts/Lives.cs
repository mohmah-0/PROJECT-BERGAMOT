using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 30;
    public bool hasRespawned = true;
    public void OutOfView()
    {
        if (lives > 0 && hasRespawned)
        {
            lives--;
            GameObject leadCar = CrossChecking.cars[0].carObject.transform.GetChild(0).gameObject;
            hasRespawned = false;
            StartCoroutine(GetComponent<Respawn>().CarRespawn());
        }
    }
}
