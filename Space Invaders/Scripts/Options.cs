using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject settingMenu;
    public GameObject pauseMenu;
    public GameObject buttonsGame;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void stratGame()
    {
        startMenu.SetActive(false);
        buttonsGame.SetActive(true);
        Time.timeScale = 1;
    }

    public void settingPanel()
    {
        Time.timeScale = 0;
        settingMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        if (!startMenu.activeSelf)
        {
            Time.timeScale = 1f;
            settingMenu.SetActive(false);
        } else
        {
            settingMenu.SetActive(false);
        }
    }   

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Play()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
