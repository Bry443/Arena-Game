using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void EndGame() {
        Cursor.lockState = CursorLockMode.None;
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        Cursor.visible = true;
    }
}
