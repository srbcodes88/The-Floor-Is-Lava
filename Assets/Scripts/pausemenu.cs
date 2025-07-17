using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseUI;
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;
        GamePaused = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 0.5f;
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
