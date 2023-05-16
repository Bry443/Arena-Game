using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Bullet:MonoBehaviour
 {
     //Function will be called when this object hits an object with a collider
     void OnCollisionEnter(Collision collision)
    {    
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Capsule")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Touched gunner");
        }
        else if (collision.gameObject.name == "Player")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Touched player");
            Health.instance.TakeDamage(10);
            //Destroy this gameobject
            Destroy(gameObject);
            
        }
        else {
            Destroy(gameObject);
            Debug.Log("collided with something else");
            Debug.Log(collision.gameObject.name);
        }
        
     }
     //Destroy the gameobject 5 seconds after creation
    //Destroy(gameObject, 5.0f);    
 }    