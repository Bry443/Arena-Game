using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    [Header("Ground Check")]
    public LayerMask whatIsGround;
    bool grounded;
    public float playerHeight;

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) & grounded) {
            StaminaMovement.instance.UseStamina(10);
        }
    }
}
