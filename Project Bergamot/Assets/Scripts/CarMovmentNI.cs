using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovmentNI : MonoBehaviour
{
    private WheelCollider[] collider = new WheelCollider[4];
    private Transform[] meshes = new Transform[4];

    Vector3 tempPosition;
    Quaternion tempRotation;

    Vector2 movementInput = Vector2.zero;

    private void Awake()
    {
        meshes[0] = transform.Find("wheels").Find("wheel_frontLeft");
        meshes[1] = transform.Find("wheels").Find("wheel_frontRight");
        meshes[2] = transform.Find("wheels").Find("wheel_backLeft");
        meshes[3] = transform.Find("wheels").Find("wheel_backRight");

        collider[0] = transform.Find("wheelColliders").Find("wheel_frontLeft").GetComponent<WheelCollider>();
        collider[1] = transform.Find("wheelColliders").Find("wheel_frontRight").GetComponent<WheelCollider>();
        collider[2] = transform.Find("wheelColliders").Find("wheel_backLeft").GetComponent<WheelCollider>();
        collider[3] = transform.Find("wheelColliders").Find("wheel_backRight").GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WheelMovments();//uppdating wheel movments every frame
        PlayerControll();

    }
    
    public void onMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }


    private void WheelMovments()
    {

        for (int i = 0; i < collider.Length; i++)
        {
            collider[i].GetWorldPose(out tempPosition, out tempRotation);
            meshes[i].SetPositionAndRotation(tempPosition, tempRotation);
        }
    }


    void PlayerControll()
    {
        collider[0].steerAngle = movementInput.x * 30;
        collider[1].steerAngle = movementInput.x * 30;


        collider[2].motorTorque = movementInput.y * 1500;
        collider[3].motorTorque = movementInput.y * 1000;
    }
}
