using UnityEngine;
using UnityEngine.AI;

public class EnemyDodger : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float SightRange;
    public bool playerInSightRange;
    public float timeBetweenDodges;
    private bool enableDodging = false;
    private int dodgeCounter = 1;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        InvokeRepeating("Dodgetimer", timeBetweenDodges, timeBetweenDodges);  
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, SightRange, whatIsPlayer);
        
        if (!playerInSightRange) Patrolling();
        if (playerInSightRange) 
            {
            if (enableDodging)
                {
                    Patrolling();
                }
            else
                {
                    ChasePlayer();
                }
            }
    }

    private void Patrolling()
    {
        //Debug.Log("Patrolling");
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
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        // set destination to current player location
        agent.SetDestination(player.position);
    }

    private void Dodgetimer()
    {
        // every 'timeBetweenDodges' switches 'enableDodging' to opposite bool
        if (dodgeCounter % 2 == 0)
        {
            dodgeCounter++;
            enableDodging = true;
            agent.speed = 5;
        }
        else
        {
            enableDodging = false;
            dodgeCounter++;
            agent.speed = 15;
        }
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Touched player");
            Health.instance.TakeDamage(7);
        }
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
            dropLootScript.SpawnLoot("small");
        }
        Destroy(gameObject);
    }


    // visually shows the radius of SightRange
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SightRange);
    }
}