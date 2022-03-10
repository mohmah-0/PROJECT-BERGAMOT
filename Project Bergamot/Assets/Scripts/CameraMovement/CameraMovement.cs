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

    [Space]

    [SerializeField, Tooltip("Crosschecking handler script")]
    private CrossCheckHandler crossCheckHandler;
    
    private float damping = 1f;
    private GameObject leadCar;

    private Vector3 pathPoint;

    // Update is called once per frame
    void Update()
    {
        if (crossCheckHandler.getLeadCar() != null) 
        {
            leadCar = crossCheckHandler.getLeadCar().transform.GetChild(0).gameObject; //Gets the rigidbody to get the transformation(position)

            float currentAngle = transform.eulerAngles.y;
            float desiredAngle = leadCar.transform.eulerAngles.y;
            float angle = Mathf.LerpAngle(currentAngle, desiredAngle, damping);

            pathPoint = FollowPath.path.GetClosestPointOnPath(leadCar.transform.position); //Gets the closest point on the path from the leadcar's position.

            //Rotation is only to smooth curves and to make sure the camera faces the correct way. Just a safty for the Lookat.
            Quaternion rotation = Quaternion.Slerp(FollowPath.path.GetRotationAtDistance(FollowPath.path.GetClosestDistanceAlongPath(leadCar.transform.position)), Quaternion.Euler(0f, angle, 0f), 0.125f);
            transform.position = pathPoint - (rotation * offset);

            transform.LookAt(leadCar.transform.position);

        } else
        {
            //If no leadcar has been found, this will setup the camera so its ready for the leadcar input.
            pathPoint = FollowPath.path.GetPointAtDistance(1);
            transform.position = pathPoint - (transform.rotation * offset);
        }

    }

    /*
     * When a lap has been done, the camera should zoom in a bit per lap.
     */
    public void zoomCamera(int multiplyer)
    {
        offset = new Vector3(offset.x, offset.y + multiplyer, offset.z - (0.5f * multiplyer));
    }
}

