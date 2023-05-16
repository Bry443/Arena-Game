using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    public bool goHome;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && !goHome)
        {
            // Loads the next scene level
            SceneManager.LoadScene(1);
            Debug.Log("Loading Level 01");
        }
        else if (other.gameObject.name == "Player" && goHome)
        {
            // Loads the next scene level
            SceneManager.LoadScene(0);
            Debug.Log("Returning to scene_Main");
        }
    }
}
