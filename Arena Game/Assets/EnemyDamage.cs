using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public Health hitpoints;
    public float damage = 10f;

    public void OnCollision(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hitpoints.TakeDamage(damage);
        }
    }

}
