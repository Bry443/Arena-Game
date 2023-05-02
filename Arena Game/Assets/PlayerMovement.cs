using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some credit goes to Dave at https://www.youtube.com/watch?v=f473C43s8nE

public class PlayerMovement : MonoBehaviour
{
    // Useful Headers
    [Header("Movement")]
    
    // Movement & Physics Parameters
    public float playerHeight;
    public float moveSpeed;
    public float jumpForce;
    public float groundDrag;
    public float airMultiplier;
    
    bool readyToJump;       // Used to check if jump is possible (Ex: Player needs Stamina to jump)

    [Header("Ground Check")]
    public LayerMask whatIsGround;
    bool grounded;

    Rigidbody rb;
    public Transform orientation;

    float xz_Input; // Horizontal input
    float y_Input;  // Vertical input

    Vector3 moveDirection;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Starting Controls");
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component just once
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        PlayerInput();

        // handle drag
        if (grounded) rb.drag = groundDrag;
        else rb.drag = 0;
        
        // Implements vertical jumps (Can only jump if touching ground)
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlayerInput()
    {
        xz_Input = Input.GetAxis("Horizontal");
        y_Input = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction           
        moveDirection = orientation.forward * y_Input + orientation.right * xz_Input;

        // Force used for moving player character on ground or mid-air
        if (grounded) rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded) rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);
    }

}
