using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    public GameObject ItemsMenuCanvas;
    public GameObject Pistol;
    public GameObject Shotgun;
    public GameObject SniperRifle;
    public GameObject MachineGun;
    public KeyCode PauseKey = KeyCode.T;
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PauseKey)) {
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
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Paused = true;
    }

    public void Play() {
        PauseMenuCanvas.SetActive(false);
        ItemsMenuCanvas.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
        Paused = false;
    }

    public void LoadItemsMenu() {
        PauseMenuCanvas.SetActive(false);
        ItemsMenuCanvas.SetActive(true);
    }

    public void LoadEndGameScene() {
        SceneManager.LoadScene("EndGame");
    }

    public void MainMenuButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Gun1Button() {
        // Set everyting inactive
        Shotgun.SetActive(false);
        SniperRifle.SetActive(false);
        MachineGun.SetActive(false);
        
        Pistol.SetActive(true);     // Set Gun as active
        Play();                     // Resume game with Play()
    }
    public void Gun2Button() {
        // Set everyting inactive
        Pistol.SetActive(false);
        SniperRifle.SetActive(false);
        MachineGun.SetActive(false);
        
        Shotgun.SetActive(true);     // Set Gun as active
        Play();                     // Resume game with Play()
    }
    public void Gun3Button() {
        // Set everyting inactive
        Shotgun.SetActive(false);
        Pistol.SetActive(false);
        MachineGun.SetActive(false);
        
        SniperRifle.SetActive(true);     // Set Gun as active
        Play();                     // Resume game with Play()
    }
    public void Gun4Button() {
        // Set everyting inactive
        Shotgun.SetActive(false);
        SniperRifle.SetActive(false);
        Pistol.SetActive(false);
        
        MachineGun.SetActive(true);     // Set Gun as active
        Play();                     // Resume game with Play()
    }

}
