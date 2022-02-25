using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrossChecking : MonoBehaviour
{
    public static List<Car> cars = new List<Car>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < cars.Count - 1; i++)//checking if any cars passed each other
        {
            if (hasCar2PassedCar1(cars[i], cars[i + 1]))
            {
                Car tempCar1 = cars[i], tempCar2 = cars[i + 1];
                cars[i] = tempCar2;
                cars[i + 1] = tempCar1;
            }
        }

        for (int i = 0; i < cars.Count; i++)
        {
            cars[i].carObject.name = "Racing" + i;
        }
    }


    public static void applyCrossChecking(PlayerInput car)//this is for applying crosschecking for the spawned call
    {
        cars.Add(new Car(car.gameObject));
    }

    bool hasCar2PassedCar1(Car car1, Car car2)
    {
        if((car1.currentCheckpoint > car2.currentCheckpoint) || ((car1.currentCheckpoint == car2.currentCheckpoint) && (car1.checkpointDistance() < car2.checkpointDistance())))
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    public void checkpointTriggerOccurred(GameObject carObject, GameObject checkPointObject)//uppdates the chechpoint, is used every time checkpoint is triggered
    {
        for(int i = 0; i < cars.Count; i++)
        {
            if ((cars[i].carObject == carObject.transform.parent.parent.gameObject) && (checkPointObject.transform.parent.gameObject == cars[i].checkPoints[cars[i].currentCheckpoint].transform.parent.gameObject))
            {
                if (cars[i].currentCheckpoint == cars[i].checkPoints.Count - 1)
                {
                    cars[i].carObject.GetComponent<CarMovment>().EnteredGoal = true;
                }
                else
                {
                    cars[i].currentCheckpoint++;
                }
            }
        }
    }

}


public class Car // this is almost compleatly to both orgenize and avoid uneccesary calculations.(we dont want shove every cars information in the same class but at the same time we dont want to make each car to calculate it's own place in leaderboard).
{
    public GameObject carObject;
    public List<GameObject> checkPoints = new List<GameObject>();
    public int currentCheckpoint = 0;


    public Car(GameObject carObject)
    {
        this.carObject = carObject;
        checkPoints.AddRange(GameObject.FindGameObjectsWithTag("checkPoint"));
    }


    public Vector3 position()
    {
        return carObject.transform.Find("RigidBody").position;
    }


    public float checkpointDistance()
    {
        return Vector3.Distance(position(), checkPoints[currentCheckpoint].transform.position);
    }
}
