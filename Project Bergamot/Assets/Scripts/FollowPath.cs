using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{

    public PathCreator pathToFollow;
    public Rigidbody speedTargetObject; //Will be used when car mechanics is done!
    public Vector3 offset;
    public float smoothTurn = 0.125f;
    float distanceTravelled;


    void Start()
    {
        transform.position = pathToFollow.path.GetPointAtDistance(speedTargetObject.position.x);
        distanceTravelled = speedTargetObject.position.x-25;
    }

    // Update is called once per frame
    void Update()
    {


        distanceTravelled += speedTargetObject.velocity.magnitude * Time.deltaTime;
        Vector3 targetpos = pathToFollow.path.GetPointAtDistance(distanceTravelled) + offset;
        Quaternion targetrot = pathToFollow.path.GetRotationAtDistance(distanceTravelled) * Quaternion.Euler(45, 0, 0);

        transform.position = targetpos;
        transform.rotation = Quaternion.Slerp(targetrot, speedTargetObject.rotation, smoothTurn);
    }
}
