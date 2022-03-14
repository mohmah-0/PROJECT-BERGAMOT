using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CrossCheckHandler : MonoBehaviour
{
    [SerializeField, Tooltip("Path to place checkpoints on.")]
    private PathCreator TrackPath;
    [SerializeField, Tooltip("Checkpoint prefab.")]
    private GameObject Checkpoint;
    [SerializeField, Tooltip("SpawnPoints, used for offsetting checkpoint system")]
    private GameObject SpawnPointHolder;

    [Space]

    [SerializeField, Tooltip("Distance between checkpoints")]
    private float CheckpointDistance = 40.0f;


    //CarsData
    public GameObject[] cars;
    public GameObject leadCar;
    
    //CheckpointData
    private GameObject[] checkpoints;
    private List<int> nextCheckPointList;

    //PathData
    private float pathDist = 0;
    private float CheckpointAmount = 0;


    // Start is called before the first frame update
    void Start()
    {
        pathDist = TrackPath.path.length;
        CheckpointAmount = pathDist / CheckpointDistance;
        float CheckpointOffset = TrackPath.path.GetClosestDistanceAlongPath(SpawnPointHolder.transform.position)+5;

        //Sets up the checkpoints
        for(int i = 0; i < CheckpointAmount; i++)
        {
            Vector3 currentPointpos = TrackPath.path.GetPointAtDistance((CheckpointDistance * i) + CheckpointOffset) + new Vector3(0, 3, 0);
            Quaternion currentPointRot = TrackPath.path.GetRotationAtDistance((CheckpointDistance * i) + CheckpointOffset);
            Quaternion targetRot = new Quaternion(90, currentPointRot.y, currentPointRot.z, currentPointRot.w);

            GameObject newCheckPoint = Instantiate(Checkpoint, currentPointpos, currentPointRot, this.transform);
            newCheckPoint.transform.Rotate(-90, 180, 0);
            newCheckPoint.GetComponent<CheckPoint>().setID(i);
        }
        checkpoints = GameObject.FindGameObjectsWithTag("checkPoint");
        checkpoints[0].GetComponent<CheckPoint>().goal = true;

        //Sets up the next checkpoint system for all the cars Also finds the cars
        nextCheckPointList = new List<int>();
        cars = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < cars.Length; i++)
        {
            nextCheckPointList.Add(0);
        }

        //Sets the leadcar to the first car joined
        leadCar = cars[0];
    }

    // Update is called once per frame
    void Update()
    {
        //Temporarly added. pre-adding cars has not been setup yet.
        cars = GameObject.FindGameObjectsWithTag("Player");

        if (cars.Length == 0)
            return;

        if(nextCheckPointList.Count < cars.Length)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                nextCheckPointList.Add(0);
            }
        }

        int highestlap = 0;
        int highestCheckPoint = 0;
        float longestDistance = 0.0f;

        //Collects the data from the cars, which is the furthest dist etc.
        for(int i = 0; i < cars.Length; i++)
        {
            CarCheckPointData carData = cars[i].GetComponent<CarCheckPointData>(); //This gets the Car's data for the crosschecking system.
            if(carData.getCurrentLap() >= highestlap)
            {
                highestlap = carData.getCurrentLap();
            }
            if(carData.getCurrentCheckpoint() >= highestCheckPoint)
            {
                highestCheckPoint = carData.getCurrentCheckpoint();
            }
            if (TrackPath.path.GetClosestDistanceAlongPath(cars[i].transform.GetChild(0).position) >= longestDistance)
            {
                longestDistance = TrackPath.path.GetClosestDistanceAlongPath(cars[i].transform.GetChild(0).position);
            }
        }

        //Checks which car that is in the lead
        for (int i = 0; i < cars.Length; i++)
        {
            CarCheckPointData carData = cars[i].GetComponent<CarCheckPointData>();
            if (highestlap == carData.getCurrentLap())
            {
                if (highestCheckPoint == carData.getCurrentCheckpoint())
                {
                    if (longestDistance == TrackPath.path.GetClosestDistanceAlongPath(cars[i].transform.GetChild(0).position))
                    {
                        leadCar = cars[i];
                    }
                }
            }
        }
    }

    /*
     * This returns the car in lead.
     */
    public GameObject getLeadCar()
    {
        if(cars != null)
        {
           return leadCar;
        }
        return null;
    }

    /*
     * This handles the Collition with checkpoints.
     */
    public void onCollide(int id, GameObject car, bool goal)
    {

        if (car != null)
        {
            if(goal && leadCar.GetComponent<CarCheckPointData>().getCurrentCheckpoint() == (checkpoints.Length - 1))
            {
                GameObject camera = GameObject.FindWithTag("MainCamera");
                camera.GetComponent<CameraMovement>().zoomCamera(leadCar.GetComponent<CarCheckPointData>().getCurrentLap() + 1);
            }
            for(int i = 0; i < cars.Length; i++)
            {
                int nextCheckPoint = nextCheckPointList[i];
                CarCheckPointData carData = cars[i].GetComponent<CarCheckPointData>();
                if(cars[i] == car)
                {
                    if (id == nextCheckPoint)
                    {
                        if(goal && carData.getCurrentCheckpoint() == checkpoints.Length - 1)
                        {
                            carData.setCurrentLap(carData.getCurrentLap() + 1);
                            carData.setCurrentCheckpoint(0);
                        }
                        carData.setCurrentCheckpoint(id);
                        nextCheckPointList[i] = (nextCheckPoint + 1) % checkpoints.Length;

                    }
                    Debug.Log(carData.getCurrentCheckpoint() + " / " + (checkpoints.Length-1));
                    //break;
                }
            }
        }
    }

    /*
     * When a car goes out of screen it should get the leadcar's data
     * so it does not miss any checkpoints and destroy the system.
     */
    public void onOutOfBounds(GameObject car)
    {
        int currentLeaderIndex = 0;
        int targetCarIndex = 0;

        for(int i = 0; i < cars.Length;i++)
        {
            if(leadCar == cars[i])
                currentLeaderIndex = i;
            if(car == cars[i])
                targetCarIndex = i;
        }

        CarCheckPointData leadCarData = cars[currentLeaderIndex].GetComponent<CarCheckPointData>();
        CarCheckPointData targetCarData = cars[targetCarIndex].GetComponent<CarCheckPointData>();

        if (currentLeaderIndex != targetCarIndex)
        {
            targetCarData.setCurrentCheckpoint(leadCarData.getCurrentCheckpoint());
            targetCarData.setCurrentLap(leadCarData.getCurrentLap());

            nextCheckPointList[targetCarIndex] = nextCheckPointList[currentLeaderIndex];

        }
    }
}
