using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;
    public float maxStamina = 1000f;
    public static float CurrentStamina = 1000f;
    
    private static float regenRate = 0.1f;
    //private static float drainRate = 1f;
    
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
        //CurrentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = CurrentStamina;
        if (CurrentStamina < maxStamina) regen = StartCoroutine(RegenStamina());
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
        }
        regen = null;
        if (CurrentStamina > maxStamina) CurrentStamina = maxStamina;
    }

    // Restore an amount of Stamina
    public void RestoreStamina(float amount)
    {
        CurrentStamina += amount;
        staminaBar.value = CurrentStamina;
        Debug.Log(amount + " Stamina restored!");

        if (CurrentStamina > maxStamina) CurrentStamina = maxStamina;
    }


    public float GetCurrentStamina()
    {
        return CurrentStamina;
    }



}
