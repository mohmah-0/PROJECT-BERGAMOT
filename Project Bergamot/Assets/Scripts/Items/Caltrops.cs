using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caltrops : Item
{
    public override void DisplayItem()
    {
        throw new System.NotImplementedException();
    }

    float distance = 3;
    public override void Use(GameObject car)
    {
        float angle = -car.transform.eulerAngles.y * Mathf.PI / 180 + Mathf.PI / 2;

        float x = car.transform.position.x - Mathf.Cos(angle) * distance;
        float y = car.transform.position.y;
        float z = car.transform.position.z - Mathf.Sin(angle) * distance;

        Instantiate(gameObject, new Vector3(x, y, z), Quaternion.Euler(0, car.transform.rotation.y, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Rigidbody rb = other.transform.parent.GetComponent<Rigidbody>();
        rb.velocity /= 4;
        Destroy(gameObject);
    }
}
