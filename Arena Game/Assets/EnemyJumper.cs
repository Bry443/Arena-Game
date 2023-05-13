using UnityEngine;
using UnityEngine.AI;
using System.Threading;

// [RequireComponent(typeof(NavMeshAgent))]
// [RequireComponent(typeof(Rigidbody))]
public class EnemyJumper : MonoBehaviour
{
    private NavMeshAgent enemy;
    private Rigidbody rb;
    public Transform PlayerTarget;
    public float jumpForce;
    public float jumpInterval = 2.0f;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Jump", jumpInterval, jumpInterval);
    }

    void Jump()
    {
        // Temporarily disable NavMeshAgent component
        enemy.enabled = false;

        // Apply upward force to make the bot jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Re-enable NavMeshAgent component after jump is complete
        Invoke(nameof(EnableNavMeshAgent), 1.0f);
    }
    

    void EnableNavMeshAgent()
    {
    NavMeshHit hit;
    bool onNavMesh = NavMesh.SamplePosition(enemy.transform.position, out hit, 0.1f, NavMesh.AllAreas); //Test if bot touching walkable surface
    while (onNavMesh == false)
    {
        Debug.Log("NavMesh is not touching ground.");
        Thread.Sleep(1000); // wait 1000 milliseconds
    }
    Debug.Log("NavMesh is touching ground.");
    enemy.enabled = true;
    }

    void Update()
    {
        enemy.SetDestination(PlayerTarget.position);
    }
}
