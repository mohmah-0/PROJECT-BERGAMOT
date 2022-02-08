using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;
    Vector2 input;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        input = new Vector2(horizontal, vertical).normalized;

        if (Input.GetKeyDown(KeyCode.E))
            GetComponent<Inventory>().item.GetComponent<Item>().Use(gameObject);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(input.x, rb.velocity.y, input.y);
    }
}
