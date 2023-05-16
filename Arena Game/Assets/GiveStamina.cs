using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveStamina : MonoBehaviour
{
    public Stamina staminabar;
    public float amount = 200f;

    public void OnTriggerGive(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Touching Object");
            Stamina.instance.RestoreStamina(amount);
            //staminabar.RestoreStamina(amount);
            Destroy(gameObject);
        }
    }
}
