using UnityEngine;
using UnityEngine.AI;
using System.Collections;

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
                //Jump();
                //invoke(Jump() 1f)
                StartCoroutine(Jump());
                nextJumpTime = Time.time + timeBetweenJumps;
            }
        }
        else
        {
            agent.enabled = false;
            rb.isKinematic = false;
        }
    }

    private IEnumerator Jump()
    {
        isGrounded = false;
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        yield return new WaitForSeconds(2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (whatIsGround == (whatIsGround | (1 << collision.gameObject.layer)))
        {
            isGrounded = true;
        }
    }
}
