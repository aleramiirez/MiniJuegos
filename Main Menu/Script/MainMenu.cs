using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject gamesPanel1;

    public GameObject gamesPanel2;

    public GameObject settingPanel;

    public void Games()
    {
        gamesPanel1.SetActive(true);
    }

    public void Setting()
    {
        gamesPanel1.SetActive(false);
        gamesPanel2.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    /** Panel de juegos **/

    public void NextPage()
    {
        gamesPanel1.SetActive(false);
        gamesPanel2.SetActive(true);
    }
    
    public void PreviusPage()
    {
        gamesPanel2.SetActive(false);
        gamesPanel1.SetActive(true);
    }

    public void Pong()
    {
        SceneManager.LoadScene("Menu Pong");
    }

    public void SnowballWar()
    {
        SceneManager.LoadScene("Menu Snowball");
    }

    public void FlappyBird()
    {
        SceneManager.LoadScene("Flappy Bird");
    }

    public void JimmyVsCovid()
    {
        SceneManager.LoadScene("Menu Jimmy vs Covid");
    }
    
    public void SpaceInvaders()
    {
        SceneManager.LoadScene("Game Space Invaders");
    }

    public void CloseSettings()
    {
        settingPanel.SetActive(false);
    }

}
