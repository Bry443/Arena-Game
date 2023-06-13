using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        var Hit_entity = collision.gameObject;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health.instance.TakeDamage(10);
            Destroy(collision.transform.gameObject);
        }
     
    }
}
