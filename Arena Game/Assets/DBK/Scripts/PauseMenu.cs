using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            if (Paused) {
                Play();
            }
            else {
                Stop();
            }
        }
    }

    void Stop() {
        PauseMenuCanvas.SetActive(true); 
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Play() {
        PauseMenuCanvas.SetActive(false); 
        Time.timeScale = 1f;
        Paused = false;
    }

    public void LoadEndGameScene() {
        SceneManager.LoadScene("EndGame");
    }

    public void MainMenuButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    // .buildIndex - 1
}
