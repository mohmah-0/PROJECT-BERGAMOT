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

    [SerializeField, Tooltip("Current Checkpoint")]
    private int Currentlap = 0;

    [Space]

    [SerializeField, Tooltip("Distance between checkpoints")]
    private float CheckpointDistance = 40.0f;


    private GameObject[] cars;
    public GameObject[] checkpoints;
    private float pathDist = 0;
    private float CheckpointAmount = 0;
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
            newCheckPoint.GetComponent<CheckPoint>().setID(i+1);
        }
        checkpoints = GameObject.FindGameObjectsWithTag("checkPoint");

        checkpoints[0].gameObject.GetComponent<MeshRenderer>().enabled = true;

        cars = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cars.Length);
        for(int i = 0; i < cars.Length-1; i++)
        {
            CarCheckPointData carData = cars[i].GetComponent<CarCheckPointData>();
            if(carData.getCurrentCheckpoint() == checkpoints.Length-1)
            {
                carData.setCurrentCheckpoint(0);
                carData.setCurrentLap(carData.getCurrentLap() + 1);
            }
        }
    }

    public GameObject getLeadCar()
    {
        if(cars != null)
        {
           return cars[0];
        }
        return null;
    }

    public void onCollide(int id, GameObject car)
    {
        if(car != null)
        {
            for(int i = 0; i < cars.Length; i++)
            {
                CarCheckPointData carData = cars[i].GetComponent<CarCheckPointData>();
                if(cars[i] == car)
                {
                    if (id == carData.getCurrentCheckpoint() + 1)
                    {
                        checkpoints[id].gameObject.GetComponent<MeshRenderer>().enabled = true;
                        checkpoints[carData.getCurrentCheckpoint()].gameObject.GetComponent<MeshRenderer>().enabled = false;
                        carData.setCurrentCheckpoint(id);
                        Debug.Log(carData.getCurrentCheckpoint() + " / " + (checkpoints.Length));

                        break;
                    }
                }
            }
        }
    }

}
