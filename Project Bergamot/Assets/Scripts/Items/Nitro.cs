using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : Item
{
    public override void Use(GameObject car)
    {

        Rigidbody rb = car.GetComponent<Rigidbody>();
        Vector3 dir = rb.velocity.normalized;
        Debug.Log(dir);
        rb.AddForce(dir * 1000, ForceMode.Impulse);
        FindObjectOfType<AudioManager>().Play("Nitro");
    }
}
