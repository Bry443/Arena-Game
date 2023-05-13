using UnityEngine;
using UnityEngine.AI;

// [RequireComponent(typeof(NavMeshAgent))]
// [RequireComponent(typeof(Rigidbody))]
public class EnemyRunner : MonoBehaviour
{
    private NavMeshAgent enemy;
    public Transform PlayerTarget;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        enemy.SetDestination(PlayerTarget.position);
    }
}