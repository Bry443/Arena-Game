using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Controls");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))  // Jump
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 0);
        }
        
        if (Input.GetKey("a"))  // Move Left
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-4, 0, 0);
        }

        if (Input.GetKey("d"))  // Move Right
        {
            GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 0);
        }

        if (Input.GetKey("w"))  // Move Forward
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
        }

        if (Input.GetKey("s"))  // Move Backward
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -4);
        }
    }
}
