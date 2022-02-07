using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody leadcar;
    public PathCreator FollowPath;
    public Vector3 offset;
    float damping = 1f;

    Vector3 pathPoint;

    // Update is called once per frame
    void Update()
    {

        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = leadcar.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, damping);

        pathPoint = FollowPath.path.GetClosestPointOnPath(leadcar.position);
        
        Quaternion rotation = Quaternion.Slerp(FollowPath.path.GetRotationAtDistance(FollowPath.path.GetClosestDistanceAlongPath(leadcar.position)),Quaternion.Euler(0f, angle, 0f),0.125f);
        transform.position = pathPoint - (rotation * offset);

        transform.LookAt(leadcar.transform.position);

    }
}
