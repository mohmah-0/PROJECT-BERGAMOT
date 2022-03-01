using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfView : MonoBehaviour
{

    [SerializeField] GameObject[] cars;
    float startTime = 10;
    // Update is called once per frame
    void Update()
    {
        cars = GameObject.FindGameObjectsWithTag("PlayerHitbox");
        startTime -= Time.deltaTime;
        foreach (GameObject car in cars)
        {
            if (!IsVisible(car) && startTime < 0)
            {
                car.transform.parent.parent.GetComponent<Lives>().OutOfView();
            }
        }
    }

    bool IsVisible(GameObject car)
    {
        return car.GetComponent<Renderer>().isVisible;
    }
}
