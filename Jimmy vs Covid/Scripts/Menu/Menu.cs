using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game Jimmy vs Covid");
    }

    public void Setting()
    {
        
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
