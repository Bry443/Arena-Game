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
                    Debug.Log("Returning to scene_Main");
                    SceneManager.LoadScene(0);  // Should load scene_Main
                    break;
                case 1:
                    Debug.Log("Loading Level 01");
                    SceneManager.LoadScene(1);  // Loads the next scene level
                    break;
                case 2:
                    Debug.Log("Loading Level 02");
                    SceneManager.LoadScene(2);
                    break;
                case 3:
                    Debug.Log("Loading Level 03");
                    SceneManager.LoadScene(3);
                    break;
                case 4:
                    Debug.Log("Loading Level 04");
                    SceneManager.LoadScene(4);
                    break;
                default:
                    Debug.Log("Invalid Level or no level found");
                    break;
            }
        }
            
    }
}
