using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaMovement : MonoBehaviour
{
    public Slider staminaBar;
    private int maxStamina = 100;
    private int currentStamina;

    public static StaminaMovement instance;

    private void Awake() {
        instance = this;
    }
    
    void start() {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }
    public void UseStamina(int amount) {
        if (currentStamina - amount >= 0) {
            currentStamina -= amount;
            staminaBar.value = currentStamina;
        }
        else {
            Debug.Log("not enough stamina");
        }
    }

}
