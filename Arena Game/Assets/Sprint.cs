using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            StaminaMovement.instance.UseStamina(15);
        }
    }
}
