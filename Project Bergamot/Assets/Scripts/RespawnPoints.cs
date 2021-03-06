using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class RespawnPoints : MonoBehaviour
{
    [SerializeField] GameObject RespawnPoint;

    [SerializeField, Tooltip("The path the camera will follow.")]
    private PathCreator FollowPath;
    [SerializeField, Tooltip("The camera offset to the car and track.")]
    private Vector3 offset;

    [Space]

    [SerializeField, Tooltip("Crosschecking handler script")]
    private CrossCheckHandler crossCheckHandler;

    private float damping = 1f;
    private GameObject leadCar;

    private Vector3 pathPoint;
    private void Start()
    {
        for (int i = 1; i < 5; i++)
        {
            GameObject point = Instantiate(RespawnPoint, transform);
            point.transform.localPosition = new Vector3(-3 + i * 1.5f, 0, 0) ;
            point.name = "point" + i;
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (crossCheckHandler.getLeadCar() != null)
        {
            leadCar = crossCheckHandler.getLeadCar().transform.GetChild(0).gameObject;

            float currentAngle = transform.eulerAngles.y;
            float desiredAngle = leadCar.transform.eulerAngles.y;
            float angle = Mathf.LerpAngle(currentAngle, desiredAngle, damping);

            pathPoint = FollowPath.path.GetClosestPointOnPath(leadCar.transform.position);

            Quaternion rotation = Quaternion.Slerp(FollowPath.path.GetRotationAtDistance(FollowPath.path.GetClosestDistanceAlongPath(leadCar.transform.position)), Quaternion.Euler(0f, angle, 0f), 0.125f);
            transform.position = pathPoint - (rotation * offset);

            Vector3 lookAtPos = pathPoint - (rotation * offset - new Vector3(0, 0, -0.1f));
            transform.LookAt(pathPoint);
        }
        else
        {
            pathPoint = FollowPath.path.GetPointAtDistance(1);
            transform.position = pathPoint - (transform.rotation * offset);
        }
    }
}
