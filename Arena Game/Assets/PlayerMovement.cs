using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some credit goes to Dave at https://www.youtube.com/watch?v=f473C43s8nE

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] AudioSource jumpSound;
    // [SerializeField] AudioSource walkingSound;
    // Useful Headers
    [Header("Movement")]

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    public static PlayerMovement instance;


    [Header("Movement Parameters")]
    public float playerHeight = 3;
    public float walkSpeed = 6;
    public float sprintSpeed = 10;
    public float crouchSpeed = 4;
    public float jumpForce = 10;
    public float groundDrag = 10;
    public float airMultiplier = 0;

    [Header("Crouching")]
    public float crouchYScale = 1;
    private float startYScale;

    [Header("Stamina Costs")]
    public float currentStamina;
    public float jumpStamina = 20;
    public float sprintStamina = 2;

    [Header("Ground Check")]
    public LayerMask whatIsGround;
    bool grounded;

    Rigidbody rb;
    public Transform orientation;
    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        freefall,
        crouching
    }

    float xz_Input; // Horizontal input
    float y_Input;  // Vertical input
    private float moveSpeed;

    Vector3 moveDirection;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Starting Controls");
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component just once
        rb.freezeRotation = true;
        startYScale = transform.localScale.y;
        Cursor.visible = false;
    }

    private void Update()
    {
        // if (GetState() == MovementState.walking){
        //     walkingSound.enabled = true;
        // }
        // else{
        //     walkingSound.enabled = false;
        // }
        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        StateHandler();
        PlayerInput();

        currentStamina = Stamina.instance.GetCurrentStamina();

        // Implements vertical jumps (Can only jump if touching ground)
        if (Input.GetKeyDown(jumpKey) && grounded)
        {
            jumpSound.Play();
            if (currentStamina > jumpStamina)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                Stamina.instance.UseStamina(jumpStamina); // Use Stamina to Jump }
            }
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 15f, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.C)) {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
       
       
        if (Input.GetKeyDown(KeyCode.Tab)) {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        // handle drag
        if (grounded) rb.drag = groundDrag;
        else rb.drag = 0;
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

    private void StateHandler()
    {

        // Sprinting State
        if (grounded && Input.GetKey(sprintKey) && !Input.GetKey(KeyCode.C))
        {
            if (currentStamina > 0)
            {
                state = MovementState.sprinting;
                moveSpeed = sprintSpeed;
                Stamina.instance.UseStamina(sprintStamina); // Use Stamina when Sprinting
            }
            else moveSpeed = walkSpeed;
        }
        // Crouching State
        else if (Input.GetKey(KeyCode.C)) {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }
        // Walking State
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        // Freefall State
        else if (!grounded)
        {
            state = MovementState.freefall;
        }
    }

    public MovementState GetState()
    {
        return state;
    }

    private void MovePlayer()
    {
        // calculate movement direction           
        moveDirection = orientation.forward * y_Input + orientation.right * xz_Input;

        // Force used for moving player character on ground or mid-air
        if (grounded) rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);
            //Debug.Log("Current Force midair" + rb.GetAccumulatedForce);
            
        }

    }

    public void BoostSprint(float amount)
    {
        sprintSpeed += amount;
    }

}
