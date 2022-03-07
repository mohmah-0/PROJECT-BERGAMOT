//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using PathCreation;

//public class FollowPath : MonoBehaviour
//{

//    public PathCreator pathToFollow;
//    public GameObject speedTargetObject; //Will be used when car mechanics is done!
//    public float speed = 5;
//    public Vector3 offset;
//    public float smoothTurn = 0.125f;
//    float distanceTravelled;

//    float vertical;

//    void Start()
//    {
//        transform.position = pathToFollow.path.GetPointAtDistance(0);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //vertical = Input.GetAxis("Vertical"); had to comment out so that it wont spamm error messages. The error comes from using the old input system while we use the new one.

//        distanceTravelled += vertical * speed * Time.deltaTime;
//        Vector3 targetpos = pathToFollow.path.GetPointAtDistance(distanceTravelled) + offset;
//        Quaternion targetrot = pathToFollow.path.GetRotationAtDistance(distanceTravelled) * Quaternion.Euler(45, 0, 0);

//        transform.position = targetpos;
//        transform.rotation = Quaternion.Lerp(transform.rotation ,targetrot, smoothTurn);
//    }
//}
