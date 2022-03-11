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
        foreach (GameObject car in cars.ToArray())
        {
            //bool hasRespawned = car.transform.parent.parent.GetComponent<Lives>().hasRespawned;
            if (car != null)
            if (!IsVisible(car) && startTime < 0)
            {
                Debug.Log(car.transform.parent.parent.GetComponent<PlayerDetails>().playerID + "is out of view");
                car.transform.parent.parent.GetComponent<Lives>().OutOfView();
            }
        }
        if (FindObjectOfType<CrossCheckHandler>().cars.Length == 1 && startTime < 0)
            FindObjectOfType<PodiumPlacements>().FinishGame();
    }

    bool IsVisible(GameObject car)
    {
        if (car != null)
        return car.GetComponent<Renderer>().isVisible;

        return false;
    }
}
