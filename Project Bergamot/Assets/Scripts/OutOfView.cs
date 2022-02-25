using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfView : MonoBehaviour
{

    [SerializeField] GameObject[] cars;
    CrossChecking crossCheck;
    float startTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        crossCheck = GameObject.FindGameObjectWithTag("CrossChecking").GetComponent<CrossChecking>();
    }

    // Update is called once per frame
    void Update()
    {
        cars = GameObject.FindGameObjectsWithTag("PlayerHitbox");
        startTime -= Time.deltaTime;
        foreach (GameObject car in cars)
        {
            if (!IsVisible(car) && startTime < 0)
            {
                crossCheck.DestroyCar(car.transform.parent.parent.gameObject);
            }
        }
    }

    bool IsVisible(GameObject car)
    {
        return car.GetComponent<Renderer>().isVisible;
    }
}
