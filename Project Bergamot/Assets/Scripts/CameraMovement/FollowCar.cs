using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowCar : MonoBehaviour
{
    public Rigidbody leadcar;
    public PathCreator FollowPath;
    public Vector3 offset;
    public float damping = 1f;

    public float distance;
    public Vector3 path;

    float speed;

    //Vector3 path;

    void Start()
    {
        distance = (leadcar.transform.position - FollowPath.path.GetPointAtDistance(0)).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        speed = leadcar.velocity.magnitude;
        distance += speed * Time.deltaTime;
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = leadcar.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, damping);

        path = FollowPath.path.GetClosestPointOnPath(leadcar.position);
        
        Quaternion rotation = Quaternion.Slerp(FollowPath.path.GetRotationAtDistance(FollowPath.path.GetClosestDistanceAlongPath(leadcar.position)),Quaternion.Euler(0f, angle, 0f),0.125f);
        transform.position = path - (rotation * offset);

        transform.LookAt(leadcar.transform.position);

    }
}
