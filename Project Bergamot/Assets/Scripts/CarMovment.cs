using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovment : MonoBehaviour
{
    private WheelCollider[] colliders = new WheelCollider[4];
    private Transform[] meshes = new Transform[4];
    private Transform wheels, wheelColliders;
    public bool EnteredGoal = false;

    public float friction = 2, drifting = 1.5f, acceleration = 100, topSpeed = 250;

    Vector3 tempPosition;
    Quaternion tempRotation;

    private void Awake()
    {
        wheels = transform.Find("RigidBody").Find("wheels");
        meshes[0] = wheels.Find("wheel_frontLeft");
        meshes[1] = wheels.Find("wheel_frontRight");
        meshes[2] = wheels.Find("wheel_backLeft");
        meshes[3] = wheels.Find("wheel_backRight");

        wheelColliders = transform.Find("RigidBody").Find("wheelColliders");
        colliders[0] = wheelColliders.Find("wheel_frontLeft").GetComponent<WheelCollider>();
        colliders[1] = wheelColliders.Find("wheel_frontRight").GetComponent<WheelCollider>();
        colliders[2] = wheelColliders.Find("wheel_backLeft").GetComponent<WheelCollider>();
        colliders[3] = wheelColliders.Find("wheel_backRight").GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WheelMovments();//uppdating wheel movments every frame
        changingHandlingValues();
    }


    private void WheelMovments()
    {

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetWorldPose(out tempPosition, out tempRotation);
            meshes[i].SetPositionAndRotation(tempPosition, tempRotation);
        }
    }


    void changingHandlingValues()
    {
        /*if (friction != 2 || drifting != 1.5f)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                WheelFrictionCurve wheelFriction = colliders[i].forwardFriction;
                wheelFriction.stiffness = friction;
                colliders[i].forwardFriction = wheelFriction;

                wheelFriction = colliders[i].sidewaysFriction;
                wheelFriction.extremumSlip = drifting;
                colliders[i].sidewaysFriction = wheelFriction;

            }
        }*/

        for (int i = 0; i < colliders.Length; i++)//tas bort efter hittat rätt värden
        {
            WheelFrictionCurve wheelFriction = colliders[i].forwardFriction;
            wheelFriction.stiffness = friction;
            colliders[i].forwardFriction = wheelFriction;

            wheelFriction = colliders[i].sidewaysFriction;
            wheelFriction.extremumSlip = drifting;
            colliders[i].sidewaysFriction = wheelFriction;

        }

    }


    public void accelerate(InputAction.CallbackContext i)
    {


        if (!EnteredGoal && colliders[2].rpm <= topSpeed)// just to stop players from continuing after reach goal
        {
            colliders[2].motorTorque = i.ReadValue<float>() * acceleration;
            colliders[3].motorTorque = i.ReadValue<float>() * acceleration;
            colliders[2].brakeTorque = 0;
            colliders[3].brakeTorque = 0;
        }
        else
        {
            colliders[2].brakeTorque = colliders[2].rpm - topSpeed;
            colliders[3].brakeTorque = colliders[2].rpm - topSpeed;
        }

    }


    public void decelerate(InputAction.CallbackContext i)
    {


        if (!EnteredGoal)
        {
            colliders[2].motorTorque = -i.ReadValue<float>() * acceleration;
            colliders[3].motorTorque = -i.ReadValue<float>() * acceleration;
        }
    }


    public void steer(InputAction.CallbackContext i)
    {

        if (!EnteredGoal)
        {
            colliders[0].steerAngle = i.ReadValue<Vector2>().x * 30;
            colliders[1].steerAngle = i.ReadValue<Vector2>().x * 30;
        }

    }


    public void drift(InputAction.CallbackContext i)
    {
        if (i.started)
        {
            Debug.Log("trycker");
            drifting = 1.5f;
        }else if (i.canceled)
        {
            Debug.Log("släppte");
            drifting = 0.2f;
        }
    }
}
