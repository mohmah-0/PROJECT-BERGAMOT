using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{

    public PathCreator pathToFollow;
    public GameObject speedTargetObject; //Will be used when car mechanics is done!
    public float speed = 5;
    public Vector3 offset;
    float distanceTravelled;

    float vertical;

    void Start()
    {
        transform.position = pathToFollow.path.GetPointAtDistance(0);
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        distanceTravelled += vertical * speed * Time.deltaTime;
        transform.position = pathToFollow.path.GetPointAtDistance(distanceTravelled) + offset;
        transform.rotation = pathToFollow.path.GetRotationAtDistance(distanceTravelled) * Quaternion.Euler(45, 0, 0);
    }
}
