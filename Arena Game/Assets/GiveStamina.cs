using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveStamina : MonoBehaviour
{
    public float amount = 200f;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Stamina Box Touched");
        if (other.gameObject.name == "Player")
        {
            Stamina.instance.RestoreStamina(amount);
            Destroy(gameObject);
        }
    }
}
