using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public static PauseMenu pauseMenu;

    public GameObject pauseMenuUI;
    CameraController cameraController;

    void Awake()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused == true)
            {
                Resume();
            }

            else if (GameIsPaused == false)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        cameraController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        cameraController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
    }

}
