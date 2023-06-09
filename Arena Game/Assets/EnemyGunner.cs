using UnityEngine;
using UnityEngine.AI;
using System;
    
public class EnemyGunner : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform gunner;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    //Patrolling
    private Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        // change "Player" to your target
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Create bullet and add velocity
            GameObject new_bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            new_bullet.AddComponent<Bullet>();
            //objectYouCreate.AddComponent(script(ClassName));
            Rigidbody rb = new_bullet.GetComponent<Rigidbody>();
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            if (rb != null)
            {
                //Enable projectile gravity
                rb.useGravity = true;
                // Shooting velocity
                // Find player x & z distance from gunner
                double distanceFromPlayer = Math.Sqrt(Math.Pow((player.position.x - gunner.position.x),2)+Math.Pow((player.position.z - gunner.position.z),2));
                // convert to float and calculate power
                float horizontalPower = Convert.ToSingle(distanceFromPlayer * 2);
                rb.AddForce(transform.forward * horizontalPower, ForceMode.Impulse);
                rb.AddForce(transform.up * 3f, ForceMode.Impulse);
            }
            else {
                Debug.Log("Projectile missing Rigidbody");
            }
            

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        //activates the drop script before death
        DropLoot dropLootScript = GetComponent<DropLoot>();
        if (dropLootScript != null)
        {
            dropLootScript.SpawnLoot("mid");
        }
        Destroy(gameObject);
    }

// Visually shows attack and sight range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}