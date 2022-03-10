using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfView : MonoBehaviour
{

    public List<GameObject> cars;
    float startTime = 3;
    // Update is called once per frame
    void LateUpdate()
    {
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
