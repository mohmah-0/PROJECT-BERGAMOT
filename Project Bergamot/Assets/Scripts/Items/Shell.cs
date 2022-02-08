using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : Item
{
    float distance = -3;
    public override void Use(GameObject car)
    {
        //Convert angle to radians
        float angle = -car.transform.eulerAngles.y * Mathf.PI / 180 + Mathf.PI / 2;

        //calculate offset to spawn projectile
        float x = car.transform.position.x - Mathf.Cos(angle) * distance;
        float y = car.transform.position.y;
        float z = car.transform.position.z - Mathf.Sin(angle) * distance;

        Instantiate(gameObject, new Vector3(x, y, z), Quaternion.Euler(0, car.transform.eulerAngles.y, 0));
    }

    float speed = 10;
    Rigidbody rb;
    Vector3 lastVel;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Kill());
        
        float angle = -transform.eulerAngles.y * Mathf.PI / 180 + Mathf.PI / 2; // Convert angle to radians
        rb.velocity = new Vector3(Mathf.Cos(angle) * speed, rb.velocity.y, Mathf.Sin(angle) * speed); // Move projectile forward in the given angle
    }

    // Update is called once per frame
    void Update()
    {
        lastVel = rb.velocity;
    }

    void OnColliderEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Rigidbody rb = other.transform.parent.GetComponent<Rigidbody>();
        rb.velocity /= 4;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        Vector3 dir = Vector3.Reflect(lastVel.normalized, col.contacts[0].normal);
            
        rb.velocity = dir * speed;
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
