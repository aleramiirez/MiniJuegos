using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/** Clase que maneja los eventos de los botones **/
public class MainMenuManager : MonoBehaviour
{
    /** Carga la escena "Pong Game" **/
    public void ChargePongScene()
    {
        SceneManager.LoadScene("Pong Game");
    }

    public void ChargeMainScene()
    {
        SceneManager.LoadScene("Menu Pong");
    }

    /** Caraga la escena "Main Menu" **/
    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
