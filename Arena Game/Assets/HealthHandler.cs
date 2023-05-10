using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{

    public Slider HealthBar;
    public float MaxHealth = 100;
    private float CurrentHealth;

    public static HealthHandler instance;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = MaxHealth;
    }

    // Update is called once per frame
    void takeDamage(float damage) 
    {
        if (CurrentHealth -= damage >= 0)
        {
            CurrentHealth -= damage;
            HealthBar.value = CurrentHealth;
        }

        // Need to add DEATH mechanic
        else
        {
            CurrentHealth = 0f;
            HealthBar.value = CurrentHealth;
            Debug.Log("YOU DIED");
        }
    }

    void restoreHealth(float amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        HealthBar.value = CurrentHealth;

        Debug.Log(amount, " health restored!");
    }
}
