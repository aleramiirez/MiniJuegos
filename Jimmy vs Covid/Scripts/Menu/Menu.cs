using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    /** Referencia al GameObject settingPanel **/
    public GameObject settingPanel;

    public void Play()
    {
        SceneManager.LoadScene("Game Jimmy vs Covid");
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingPanel.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
