using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    public int level = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            switch (level)
            {
                case 0:
                    SceneManager.LoadScene(0);  // Should load scene_Main
                    Debug.Log("Returning to scene_Main");
                    break;
                case 1:
                    SceneManager.LoadScene(1);  // Loads the next scene level
                    Debug.Log("Loading Level 01");
                    break;
                case 2:
                    SceneManager.LoadScene(2);
                    Debug.Log("Loading Level 02");
                    break;
                default:
                    Debug.Log("Invalid Level or no level found");
                    break;
            }
        }
            
    }
}
