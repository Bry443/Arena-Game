using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 10f;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy Contact");
        if (other.gameObject.name == "Player")
        {
            Health.instance.TakeDamage(damage);
        }
    }

}
