using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float moveSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Controls");
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component just once
    }

    // Update is called once per frame
    void Update()
    {
        float x_movement = Input.GetAxis("Horizontal");
        float z_movement = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(x_movement * moveSpeed, rb.velocity.y, z_movement * moveSpeed);

        if (Input.GetButtonDown("Jump"))  // Jump
        {
            rb.velocity = new Vector3(rb.velocity.x, 8f, rb.velocity.z);
        }
        
    }
}
