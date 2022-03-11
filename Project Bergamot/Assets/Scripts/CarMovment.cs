using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CarMovment : MonoBehaviour
{
    private WheelCollider[] colliders = new WheelCollider[4];
    private Transform[] meshes = new Transform[4];
    private Transform wheels, wheelColliders;
    public bool EnteredGoal = false, accelerating = false, decelerating = false, readyForRace = false;
    InputAction.CallbackContext accelerationPower, decelerationPower;


    public float topSpeed = 600, steeringPower = 0; //ta bort acceleration och fixa dens refferenser

    Vector3 tempPosition;
    Quaternion tempRotation;


    public PlayerInput setupCar()
    {
        //Setting up the wheels(not relevant to the input system or anything)
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


        //Setting up the scripts for inputsystem
        //Debug.Log("player " + transform.parent.name + "  car: " + name);
        transform.GetComponentInParent<PlayerScript>().playerCarMovment = GetComponent<CarMovment>();
        PlayerInput tempInput = gameObject.GetComponentInParent<PlayerInput>();
        tempInput.enabled = true;

        return tempInput;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (readyForRace)
        {
            WheelMovments();//uppdating wheel movments every frame
            uppdateAcceleration();
            uppdateSteering();
        }

    }


    private void WheelMovments()
    {

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetWorldPose(out tempPosition, out tempRotation);
            meshes[i].SetPositionAndRotation(tempPosition, tempRotation);
        }
    }


    public void accelerate(InputAction.CallbackContext i, GameObject onject)
    {
        if (i.performed)// just to stop players from continuing after reach goal
        {
            accelerating = true;
            accelerationPower = i;
        }
        else if (i.canceled)
        {
            accelerating = false;
        }


    }


    public void decelerate(InputAction.CallbackContext i)
    {

        if (i.performed)// just to stop players from continuing after reach goal
        {
            decelerating = true;
            decelerationPower = i;
        }
        else if (i.canceled)
        {
            decelerating = false;
        }

    }


    public void steer(InputAction.CallbackContext i)
    {

        steeringPower = i.ReadValue<Vector2>().x * Mathf.Pow((Mathf.Abs(colliders[0].rpm) + 15) / 100, -0.5f) * 15;  // * 45 * (steeringSensetivety - colliders[0].rpm) / steeringSensetivety;
        
    }


    public void drift(InputAction.CallbackContext i)
    {
        WheelFrictionCurve temp = colliders[2].sidewaysFriction;

        if (i.started)
        {
            temp.stiffness = 2f;
            colliders[2].sidewaysFriction = temp;
            colliders[3].sidewaysFriction = temp;
        }
        else if (i.canceled)
        {
            temp.stiffness = 3f;
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

        if (EnteredGoal)// just to stop players from continuing after reach goal
        {
            colliders[2].motorTorque = 0;
            colliders[3].motorTorque = 0;

            colliders[2].brakeTorque = Mathf.Abs(colliders[2].rpm);
            colliders[3].brakeTorque = Mathf.Abs(colliders[3].rpm);
        }
        else if (accelerating && !decelerating)
        {
            topSpeed = 600 * accelerationPower.ReadValue<float>();
            colliders[2].motorTorque = calculateMotorTourqe(colliders[2].rpm);//0.005f/(0.005f*(currentAcceleration+0.9f))
            colliders[3].motorTorque = calculateMotorTourqe(colliders[3].rpm);
            colliders[2].brakeTorque = 0;
            colliders[3].brakeTorque = 0;

        }
        else if(!accelerating && decelerating)
        {
            topSpeed = 600 * decelerationPower.ReadValue<float>();
            colliders[2].motorTorque = -calculateMotorTourqe(-colliders[2].rpm);//0.005f/(0.005f*(currentAcceleration+0.9f))
            colliders[3].motorTorque = -calculateMotorTourqe(-colliders[3].rpm);
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


    void uppdateSteering()
    {
        if (EnteredGoal)// just to stop players from continuing after reach goal
        {
            colliders[0].steerAngle = 0;
            colliders[1].steerAngle = 0;
        }
        else
        {
            colliders[0].steerAngle = steeringPower;
            colliders[1].steerAngle = steeringPower;
        }
    }
}
