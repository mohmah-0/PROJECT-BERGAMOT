using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraMovement : MonoBehaviour
{
    public GameManager gameManager;
    public PathCreator FollowPath;
    public Vector3 offset;
    float damping = 1f;
    Rigidbody leadCar;

    Vector3 pathPoint;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        leadCar = gameManager.getLeadCar().transform.GetChild(0).GetComponent<Rigidbody>();

        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = leadCar.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, damping);

        pathPoint = FollowPath.path.GetClosestPointOnPath(leadCar.transform.position);
        
        Quaternion rotation = Quaternion.Slerp(FollowPath.path.GetRotationAtDistance(FollowPath.path.GetClosestDistanceAlongPath(leadCar.transform.position)),Quaternion.Euler(0f, angle, 0f),0.125f);
        transform.position = pathPoint - (rotation * offset);

        transform.LookAt(leadCar.transform.position);

    }
}
