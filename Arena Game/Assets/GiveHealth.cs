using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    public float amount = 10f;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Health Box Touched");
        if (other.gameObject.name == "Player")
        {
            Health.instance.RestoreHealth(amount);
            Destroy(gameObject);
        }
    }
    
}
