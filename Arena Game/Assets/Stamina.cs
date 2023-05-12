using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;
    private static float regenRate = 1f;
    private static float drainRate = 1f;
    public float maxStamina;
    private float CurrentStamina;

    private WaitForSeconds drainTick = new WaitForSeconds(drainRate);
    private WaitForSeconds regenTick = new WaitForSeconds(regenRate);
    private Coroutine drain;
    private Coroutine regen;
    
    public static Stamina instance;
    public MovementState state;
    
    public enum MovementState
    {
        walking,
        sprinting,
        freefall
    }

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
            CurrentStamina -= amount;
            staminaBar.value = CurrentStamina;
            if (regen != null) 
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }
        else 
        {
            Debug.Log("not enough stamina");
        }
    }

    public IEnumerator DrainStamina()
    {
        
        while (CurrentStamina != 0)
        {
            //state = PlayerMovement.instance.GetState();
            //if (PlayerMovement.instance.GetState() == MovementState.sprinting)
            CurrentStamina -= maxStamina / 100;
            staminaBar.value = CurrentStamina;
            yield return drainTick;
        }
        drain = null;
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
    }

    // Add a Restore Stamina Funciton (for pickup items that fill stamina)

}
