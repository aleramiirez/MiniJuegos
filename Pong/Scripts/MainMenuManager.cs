using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/** Clase que maneja los eventos de los botones **/
public class MainMenuManager : MonoBehaviour
{

    /** Referencia al GameObject settingPanel **/
    public GameObject settingPanel;

    /** Carga la escena "Pong Game" **/
    public void ChargePongScene()
    {
        SceneManager.LoadScene("Pong Game");
    }

    public void ChargeMainScene()
    {
        SceneManager.LoadScene("Menu Pong");
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingPanel.SetActive(false);
    }

    /** Caraga la escena "Main Menu" **/
    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
