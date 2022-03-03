using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraMovement : MonoBehaviour
{
    [SerializeField, Tooltip("The path the camera will follow.")]
    private PathCreator FollowPath;
    [SerializeField, Tooltip("The camera offset to the car and track.")]
    private Vector3 offset;
    
    private float damping = 1f;
    private GameObject leadCar;

    private Vector3 pathPoint;

    // Update is called once per frame
    void Update()
    {
        if (CrossChecking.cars.Count != 0)
        {
            leadCar = CrossChecking.cars[0].carObject.transform.GetChild(0).gameObject;

            float currentAngle = transform.eulerAngles.y;
            float desiredAngle = leadCar.transform.eulerAngles.y;
            float angle = Mathf.LerpAngle(currentAngle, desiredAngle, damping);

            pathPoint = FollowPath.path.GetClosestPointOnPath(leadCar.transform.position);

            Quaternion rotation = Quaternion.Slerp(FollowPath.path.GetRotationAtDistance(FollowPath.path.GetClosestDistanceAlongPath(leadCar.transform.position)), Quaternion.Euler(0f, angle, 0f), 0.125f);
            transform.position = pathPoint - (rotation * offset);

            transform.LookAt(leadCar.transform.position);

        } else
        {
            pathPoint = FollowPath.path.GetPointAtDistance(1);
            transform.position = pathPoint - (transform.rotation * offset);
        }

    }
}
