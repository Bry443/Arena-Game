using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;
    private static float regenRate = 0.1f;
    //private static float drainRate = 1f;
    public float maxStamina;
    public float CurrentStamina;

    //private WaitForSeconds drainTick = new WaitForSeconds(drainRate);
    private WaitForSeconds regenTick = new WaitForSeconds(regenRate);
    //private Coroutine drain;
    private Coroutine regen;
    
    public static Stamina instance;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        CurrentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(float amount)
    {
        if (CurrentStamina - amount >= 0) 
        {
            // Lose Stamina
            CurrentStamina -= amount;
            staminaBar.value = CurrentStamina;
            if (regen != null) 
            {
                // Stop Stamina regen while in action
                StopCoroutine(regen);
            }
            // Resume Stamina regen after action complete
            regen = StartCoroutine(RegenStamina());
        }
        else 
        {
            Debug.Log("not enough stamina");
        }
    }

    private IEnumerator RegenStamina() 
    {
        yield return new WaitForSeconds(1);
        while (CurrentStamina < maxStamina) 
        {
            CurrentStamina += maxStamina / 100;
            staminaBar.value = CurrentStamina;
            yield return regenTick;

            if (CurrentStamina > maxStamina) CurrentStamina = maxStamina;
        }
        regen = null;
    }

    public float GetCurrentStamina()
    {
        return CurrentStamina;
    }

    // Restore an amount of Stamina
    public void RestoreStamina(float amount)
    {
        CurrentStamina += amount;
        staminaBar.value = CurrentStamina;
    }

}
