using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnd : MonoBehaviour
{
    public void LoadEndScene() {
        SceneManager.LoadScene("EndGame");
    }
}
