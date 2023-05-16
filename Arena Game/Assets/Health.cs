using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider HealthBar;
    public float MaxHealth = 100;
    public float CurrentHealth;

    public static Health instance;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = CurrentHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damage) 
    {
        CurrentHealth = CurrentHealth - damage;
        HealthBar.value = CurrentHealth;

        // Need to add DEATH mechanic
        if (HealthBar.value <= 0)
        {
            Destroy(gameObject);    // Removes object from worldspace
            Debug.Log("YOU DIED");
        }
    }

    public void restoreHealth(float amount)
    {
        CurrentHealth = CurrentHealth + amount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        HealthBar.value = CurrentHealth;
        Debug.Log(amount + "health restored!");
    }
}
