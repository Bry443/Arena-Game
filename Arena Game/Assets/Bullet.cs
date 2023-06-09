using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Bullet:MonoBehaviour
 {
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
		if (collision.gameObject.name == "Player")
        {
            Debug.Log("Damaged player");
            Health.instance.TakeDamage(10);
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