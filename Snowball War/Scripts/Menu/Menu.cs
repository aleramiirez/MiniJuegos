using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSnowball : MonoBehaviour
{

    /** Funcion para cargar la escena del juego **/
    public void lvl1()
    {
        SceneManager.LoadScene("Game Snowball lvl1");
    }

    public void lvl2()
    {
        SceneManager.LoadScene("Game Snowball lvl2");
    }

    /** Funcion para cargar el menu principal **/
    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
