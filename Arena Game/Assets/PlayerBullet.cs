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
            Invoke(nameof(DestroySelf), 10f);
        }		
        else if (colliderMesh != null)
        {
            GetComponent<MeshCollider>().enabled = true;
            Invoke(nameof(DestroySelf), 10f);
        }
        else
        {
            Debug.Log("Projectile missing MeshCollider or SphereCollider");
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    //Function will be called when this object hits an object with a collider
    void OnCollisionEnter(Collision collision)
    {    
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Damaged bot" + bulletDamage); 
            EnemyGunner gunnerscript = collision.gameObject.GetComponent<EnemyGunner>();
            if (gunnerscript != null) gunnerscript.TakeDamage(bulletDamage);
            EnemyRunner runnerscript = collision.gameObject.GetComponent<EnemyRunner>();
            if (runnerscript != null) runnerscript.TakeDamage(bulletDamage);
            // EnemyDodger dodgerscript = collision.gameObject.GetComponent<EnemyDodger>();
            // if (dodgerscript != null) dodgerscript.TakeDamage(bulletDamage);
            //Destroy this gameobject
            Destroy(gameObject);
        }
        else {
            //Destroy(gameObject);
            //Debug.Log("collided with something else");
            Debug.Log(collision.gameObject.name);
        }
        if (collision.gameObject.name == "Lava")
        {
            Destroy(gameObject);
        }
    } 
}