using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovment : MonoBehaviour
{
    private WheelCollider[] collider = new WheelCollider[4];
    private Transform[] meshes = new Transform[4];

    public float speed = 1;

    Vector3 tempPosition;
    Quaternion tempRotation;

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
        collider[0].steerAngle = Input.GetAxis("Horizontal") * 30;
        collider[1].steerAngle = Input.GetAxis("Horizontal") * 30;


        collider[2].motorTorque = Input.GetAxis("Vertical") * 1500 * speed;
        collider[3].motorTorque = Input.GetAxis("Vertical") * 1500 * speed;
    }
}
