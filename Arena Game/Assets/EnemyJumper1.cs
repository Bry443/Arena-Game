using UnityEngine;
using UnityEngine.AI;

public class EnemyJumper1 : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody rb;
    public Transform playerTarget;
    public LayerMask whatIsGround;

    public float jumpForce;
    public float timeBetweenJumps;
    private float nextJumpTime;

    private bool isGrounded = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isGrounded)
        {
            agent.enabled = true;
            rb.isKinematic = true;
            agent.SetDestination(playerTarget.position);

            if (Time.time >= nextJumpTime)
            {
                Jump();
                nextJumpTime = Time.time + timeBetweenJumps;
            }
        }
        else
        {
            agent.enabled = false;
            rb.isKinematic = false;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (whatIsGround == (whatIsGround | (1 << collision.gameObject.layer)))
        {
            isGrounded = true;
        }
    }
}
