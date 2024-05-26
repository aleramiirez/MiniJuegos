using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSnowball : MonoBehaviour
{
    /** Referencia al GameObject settingPanel **/
    public GameObject settingPanel;

    /** Funcion para cargar la escena del juego **/
    public void lvl1()
    {
        SceneManager.LoadScene("Game Snowball lvl1");
    }

    public void lvl2()
    {
        SceneManager.LoadScene("Game Snowball lvl2");
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingPanel.SetActive(false);
    }

    /** Funcion para cargar el menu principal **/
    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
