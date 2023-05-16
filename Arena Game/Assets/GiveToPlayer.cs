using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveToPlayer : MonoBehaviour
{
    [Header("Effects: 0 = Health, 1 = Stamina, \n2 = Damage")]
    public int value = 0;
    [Header("Enter the effect magnitude: ")]
    public float amount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            switch (value)
            {
                case 0:
                    Debug.Log("Contact with Health Pickup");
                    Health.instance.RestoreHealth(amount);
                    Destroy(gameObject);
                    break;
                case 1:
                    Debug.Log("Contact with Stamina Pickup");
                    Stamina.instance.RestoreStamina(amount);
                    Destroy(gameObject);
                    break;
                case 2:
                    Debug.Log("Contact with Enemy");
                    Health.instance.TakeDamage(amount);
                    Destroy(gameObject);
                    break;
                default:
                    Debug.Log("Effect not found");
                    break;
            }
        }
    }
}
