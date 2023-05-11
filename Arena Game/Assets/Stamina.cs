using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;
    public float regenRate;
    public float drainRate;
    private int maxStamina = 100;
    private int CurrentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(regenRate);
    private Coroutine regen;

    public static Stamina instance;
    public MovementState state;

    private void Awake() {
        instance = this;
    }
    
    void Start() {
        CurrentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }
    public void UseStamina(int amount) {
        if (CurrentStamina - amount >= 0) {
            CurrentStamina -= amount;
            staminaBar.value = CurrentStamina;
            if (regen != null) {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }
        else {
            Debug.Log("not enough stamina");
        }
    }

    public IEnumerator DrainStamina(int amount)
    {
        
        while (CurrentStamina != 0)
        {
            state = PlayerMovement.instance.GetState();
            if (state = MovementState.sprinting)
            {
                CurrentStamina -= amount;
                staminaBar.value = CurrentStamina;
                yield return regenTick;
            }
            
        }
    }

    private IEnumerator RegenStamina() {
        yield return new WaitForSeconds(1);
        while (CurrentStamina < maxStamina) {
            CurrentStamina += maxStamina / 100;
            staminaBar.value = CurrentStamina;
            yield return regenTick;
        }
        regen = null;
    }

}
