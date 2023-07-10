using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet:MonoBehaviour
{
    public int bulletDamage;
    private void Update()
    {
        SphereCollider colliderSphere = GetComponent<SphereCollider>();
        MeshCollider colliderMesh = GetComponent<MeshCollider>();
        if (colliderSphere != null)
        {
            GetComponent<SphereCollider>().enabled = true;
        }		
        else if (colliderMesh != null)
        {
            GetComponent<MeshCollider>().enabled = true;
        }
        else
        {
            Debug.Log("Projectile missing MeshCollider or SphereCollider");
        }
        // call destroyself to erase bullet
        Invoke(nameof(DestroySelf), 3f);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    //Function will be called when this object hits an object with a collider
    void OnCollisionEnter(Collision collision)
    {
        var Hit_entity = collision.gameObject;
        if (Hit_entity.CompareTag("Enemy"))
        {
            Debug.Log("Damaged bot by: " + bulletDamage); 
            EnemyGunner gunnerscript = collision.gameObject.GetComponent<EnemyGunner>();
            if (gunnerscript != null) gunnerscript.TakeDamage(bulletDamage);
            EnemyRunner runnerscript = collision.gameObject.GetComponent<EnemyRunner>();
            if (runnerscript != null) runnerscript.TakeDamage(bulletDamage);
            EnemyDodger dodgerscript = collision.gameObject.GetComponent<EnemyDodger>();
            if (dodgerscript != null) dodgerscript.TakeDamage(bulletDamage);
            //Destroy this bullet
            Destroy(gameObject);
        }
        else if (Hit_entity.CompareTag("smallLoot"))
        {
            Debug.Log("Bullet Collided with LootBox");
            DropLoot dropLootScript = Hit_entity.GetComponent<DropLoot>();
            if (dropLootScript != null)
            {
                dropLootScript.SpawnLoot("small");
            }
            Destroy(collision.transform.gameObject);
        }
        else if (Hit_entity.CompareTag("midLoot"))
        {
            Debug.Log("Bullet Collided with LootBox");
            DropLoot dropLootScript = Hit_entity.GetComponent<DropLoot>();
            if (dropLootScript != null)
            {
                dropLootScript.SpawnLoot("mid");
            }
            Destroy(collision.transform.gameObject);
        }
        else if (Hit_entity.CompareTag("bigLoot"))
        {
            Debug.Log("Bullet Collided with LootBox");
            DropLoot dropLootScript = Hit_entity.GetComponent<DropLoot>();
            if (dropLootScript != null)
            {
                dropLootScript.SpawnLoot("big");
            }
            Destroy(collision.transform.gameObject);
        }

        else {
            //Destroy(gameObject);
            //Debug.Log("collided with something else");
            //Debug.Log(collision.gameObject.name);
        }
        if (Hit_entity.name == "Lava")
        {
            Destroy(gameObject);
        }
    } 
}