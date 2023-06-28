// Some credit towards this script goes to Code Monkey
// https://www.youtube.com/watch?v=LdoImzaY6M4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public KeyCode activateKey = KeyCode.E;
    public float interactRange = 2f;

    private void Update()
    {
        if (Input.GetKeyDown(activateKey))
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                Debug.Log(collider);
                //if (collider.TryGetComponent())
            }
                

        }
        

    }

}
