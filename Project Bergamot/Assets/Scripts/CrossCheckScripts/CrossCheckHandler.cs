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


    private GameObject[] cars;
    
    private GameObject[] checkpoints;
    private List<int> nextCheckPointList;

    private float pathDist = 0;
    private float CheckpointAmount = 0;

    public GameObject leadCar;
    // Start is called before the first frame update
    void Start()
    {
        pathDist = TrackPath.path.length;
        CheckpointAmount = pathDist / CheckpointDistance;
        float CheckpointOffset = TrackPath.path.GetClosestDistanceAlongPath(SpawnPointHolder.transform.position)+5;

        for(int i = 0; i < CheckpointAmount; i++)
        {
            Vector3 currentPointpos = TrackPath.path.GetPointAtDistance((CheckpointDistance * i) + CheckpointOffset) + new Vector3(0, 3, 0);
            Quaternion currentPointRot = TrackPath.path.GetRotationAtDistance((CheckpointDistance * i) + CheckpointOffset);
            Quaternion targetRot = new Quaternion(90, currentPointRot.y, currentPointRot.z, currentPointRot.w);

            GameObject newCheckPoint = (GameObject)Instantiate(Checkpoint, currentPointpos, currentPointRot, this.transform);
            newCheckPoint.transform.Rotate(-90, 180, 0);
            newCheckPoint.GetComponent<CheckPoint>().setID(i);
        }
        checkpoints = GameObject.FindGameObjectsWithTag("checkPoint");
        checkpoints[0].GetComponent<CheckPoint>().goal = true;
        nextCheckPointList = new List<int>();
        cars = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < cars.Length; i++)
        {
            nextCheckPointList.Add(0);
        }


        leadCar = cars[0];
    }

    // Update is called once per frame
    void Update()
    {
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

        for(int i = 0; i < cars.Length; i++)
        {
            CarCheckPointData carData = cars[i].GetComponent<CarCheckPointData>();
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

    public GameObject getLeadCar()
    {
        if(cars != null)
        {
           return leadCar;
        }
        return null;
    }

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
}
