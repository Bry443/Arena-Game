using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public Slider HealthBar;
    public float MaxHealth = 100f;
    public static float CurrentHealth = 100f;

    public static Health instance;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.maxValue = MaxHealth;
        //CurrentHealth = PlayerPrefs.GetFloat("health");
        HealthBar.value = CurrentHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damage) 
    {
        CurrentHealth = CurrentHealth - damage;
        HealthBar.value = CurrentHealth;

        //PlayerPrefs.SetFloat("health", CurrentHealth);  // Save Current Health to memory

        // Need to add DEATH mechanic
        if (HealthBar.value <= 0)
        {
            Death();
        }
    }

    // Restore some health to the healthbar
    public void RestoreHealth(float amount)
    {
        CurrentHealth = CurrentHealth + amount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        HealthBar.value = CurrentHealth;
        Debug.Log(amount + " Health restored!");
        //PlayerPrefs.SetFloat("health", CurrentHealth);  // Save Current Health to memory
    }

    // Carry out game over sequence and switch scene to restart menu
    public void Death()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("EndGame");

        Destroy(gameObject);    // Removes object from worldspace
        Debug.Log("YOU DIED");

        // Reset Health in Memory to full
        CurrentHealth = MaxHealth;
        //PlayerPrefs.SetFloat("health", CurrentHealth);
    }
}
