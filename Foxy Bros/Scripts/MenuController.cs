using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    /** Referencia al GameObject settingPanel **/
    public GameObject settingPanel;

    public void Level1()
    {
        SceneManager.LoadScene("Level 1 Foxy Bros");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Coins Level 1 Foxy Bros");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Enemies Level 1 Foxy Bros");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Time Level 1 Foxy Bros");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingPanel.SetActive(false);
    }
}
