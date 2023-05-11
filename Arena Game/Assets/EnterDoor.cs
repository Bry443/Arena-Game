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
        }
        else if (other.gameObject.name == "Player" && goHome)
        {
            // Loads the next scene level
            SceneManager.LoadScene(0);
        }
    }
}
