using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SayMessage : MonoBehaviour
{

    public static SayMessage instance;

    private void Awake()
    {
        instance = this;
    }

    bool talk;

    void start()
    {
        talk = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            talk = true;
            Debug.Log("COllISION: talk set to " + talk);
        }
        else
        {
            talk = false;
            Debug.Log("NO COLLISION: talk set to " + talk);
        }
           
    }

    public bool GetStatus()
    {
        return talk;
    }

    public void ResetTalk(bool talk)
    {
        talk = false;
        Debug.Log("RESET: talk set to " + talk);
    }

}
