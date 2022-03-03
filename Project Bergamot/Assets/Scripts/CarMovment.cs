using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovment : MonoBehaviour
{
    private WheelCollider[] colliders = new WheelCollider[4];
    private Transform[] meshes = new Transform[4];
    private Transform wheels, wheelColliders;
    public bool EnteredGoal = false, accelerating = false, decelerating = false;


    public float friction = 2, acceleration = 100, accelerationPower = 0; //ta bort acceleration och fixa dens refferenser
    float topSpeed = 600, steeringSensetivety = 700;//Lower sensetivety value = higher sensetivety 

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
        uppdateAcceleration();

        Debug.Log("rpm: " + colliders[3].sidewaysFriction.stiffness);
    }


    private void WheelMovments()
    {

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetWorldPose(out tempPosition, out tempRotation);
            meshes[i].SetPositionAndRotation(tempPosition, tempRotation);
        }
    }


    public void accelerate(InputAction.CallbackContext i)
    {

        if (i.performed && !EnteredGoal)// just to stop players from continuing after reach goal
        {
            accelerating = true;
            accelerationPower = i.ReadValue<float>();
        }
        else if(i.canceled || EnteredGoal)
        {
            accelerating = false;
            accelerationPower = 0;
        }


    }


    public void decelerate(InputAction.CallbackContext i)
    {



        if (i.performed && !EnteredGoal)// just to stop players from continuing after reach goal
        {
            decelerating = true;
            accelerationPower = i.ReadValue<float>();
        }
        else if (i.canceled || EnteredGoal)
        {
            decelerating = false;
            accelerationPower = 0;
        }

    }


    public void steer(InputAction.CallbackContext i)
    {

        if (!EnteredGoal)// just to stop players from continuing after reach goal
        {
            colliders[0].steerAngle = i.ReadValue<Vector2>().x * 45 * (steeringSensetivety - colliders[0].rpm) / steeringSensetivety;
            colliders[1].steerAngle = i.ReadValue<Vector2>().x * 45 * (steeringSensetivety - colliders[1].rpm) / steeringSensetivety;
        }

    }


    public void drift(InputAction.CallbackContext i)
    {
        WheelFrictionCurve temp = colliders[2].sidewaysFriction;

        if (i.started)
        {
            temp.stiffness = 1.5f;
            colliders[2].sidewaysFriction = temp;
            colliders[3].sidewaysFriction = temp;
        }
        else if (i.canceled)
        {
            temp.stiffness = 0.2f;
            colliders[2].sidewaysFriction = temp;
            colliders[3].sidewaysFriction = temp;

        }
    }


    float calculateMotorTourqe(float wheelRpm)
    {
        if((wheelRpm < topSpeed) && (wheelRpm >= 0))
        {
            return Mathf.Pow((topSpeed - wheelRpm), 2) * 0.005f;
        }
        else if(wheelRpm < topSpeed)
        {
            return topSpeed;
        }
        else
        {
            return 0;
        }
    }


    void uppdateAcceleration()
    {
        if (accelerating && !decelerating)
        {
            colliders[2].motorTorque = accelerationPower * calculateMotorTourqe(colliders[2].rpm);//0.005f/(0.005f*(currentAcceleration+0.9f))
            colliders[3].motorTorque = accelerationPower * calculateMotorTourqe(colliders[3].rpm);
            colliders[2].brakeTorque = 0;
            colliders[3].brakeTorque = 0;

        }
        else if(!accelerating && decelerating)
        {
            colliders[2].motorTorque = -accelerationPower * calculateMotorTourqe(-colliders[2].rpm);//0.005f/(0.005f*(currentAcceleration+0.9f))
            colliders[3].motorTorque = -accelerationPower * calculateMotorTourqe(-colliders[3].rpm);
            colliders[2].brakeTorque = 0;
            colliders[3].brakeTorque = 0;
        }
        else
        {
            colliders[2].motorTorque = 0;
            colliders[3].motorTorque = 0;

            colliders[2].brakeTorque = Mathf.Abs(colliders[2].rpm);
            colliders[3].brakeTorque = Mathf.Abs(colliders[3].rpm);
        }
    }
}
