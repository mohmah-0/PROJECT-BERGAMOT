using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfView : MonoBehaviour
{

    public List<GameObject> cars;
    float startTime = 3;
    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;
        foreach (GameObject car in cars)
        {
            //bool hasRespawned = car.transform.parent.parent.GetComponent<Lives>().hasRespawned;
            if (!car.GetComponent<Renderer>().isVisible && startTime < 0)
            {
                Debug.Log(car.transform.parent.parent.GetComponent<PlayerDetails>().playerID + "is out of view");
                car.transform.parent.parent.GetComponent<Lives>().OutOfView();
            }
        }

        if (FindObjectOfType<CrossCheckHandler>().cars.Length == 1 && startTime < 0)
        {
            FindObjectOfType<PodiumPlacements>().FinishGame();
        }
    }
}
