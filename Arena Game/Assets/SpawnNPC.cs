using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
	public GameObject objectToSpawn;
	public bool dead = false;
	public int spawnTimer = 10;

	private GameObject spawnedObject;
	//private ScriptName scriptName; // local variable to script instance in this object

	void Start()
	{
		spawnedObject = Instantiate(objectToSpawn);
		EnemyGunner gunnerScript = spawnedObject.GetComponent<EnemyGunner>();
	}
	
	void Update()
	{
		//if spawnedObject.
		if (dead)
		{
			Invoke(nameof(Respawn), spawnTimer);
			dead = false;
		}
	}
	void Respawn()
	{
		Start();
		//spawnedObject = Instantiate(objectToSpawn);
	}
}
