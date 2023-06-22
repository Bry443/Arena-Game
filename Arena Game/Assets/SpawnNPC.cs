using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
	public GameObject objectToSpawn;
	public int spawnTimer = 10;

	private GameObject spawnedObject;
	private EnemyGunner currentBot;
	private Transform position;
	private bool spawning = false;
	//private ScriptName scriptName; // local variable to script instance in this object

	void Start()
	{
		// currentBot = gameObject.GetComponent<EnemyGunner>();
		
		UnityEngine.AI.NavMeshHit closestHit;
		if (UnityEngine.AI.NavMesh.SamplePosition(gameObject.transform.position, out closestHit, 500f,
			    UnityEngine.AI.NavMesh.AllAreas))
		{
			var objectdetails = gameObject.transform;
			objectdetails.position = closestHit.position;
			// position.position = closestHit.position;
			spawnedObject = Instantiate(objectToSpawn, objectdetails);
			spawning = false;
		}
		else {Debug.Log("Failed to find Navmesh!");
		spawnedObject = Instantiate(objectToSpawn, gameObject.transform);}
	}
	
	void Update()
	{
		//Debug.Log(gameObject.transform.position);
		//if not already spawning and npc has been destroyed, respawn.
		if (!spawning && spawnedObject == null) 
		{
			Invoke(nameof(Start), spawnTimer);
			spawning = true;
		}

	}
	void Respawn()
	{
		spawnedObject = Instantiate(objectToSpawn, gameObject.transform);
		spawning = false;
	}
}
