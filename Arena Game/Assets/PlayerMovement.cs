using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Controls");
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component just once
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))  // Jump
        {
            rb.velocity = new Vector3(rb.velocity.x, 8f, rb.velocity.z);
        }

        if (Input.GetKey("a"))  // Move Left
        {
            rb.velocity = new Vector3(-4f, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKey("d"))  // Move Right
        {
            rb.velocity = new Vector3(4f, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKey("w"))  // Move Forward
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 4f);
        }

        if (Input.GetKey("s"))  // Move Backward
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -4f);
        }
        
    }
}
