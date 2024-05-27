using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScreen : MonoBehaviour
{
    /** Referencia al panel de login **/
    public GameObject loginPanel;

    /** Referencia al panel de registro **/
    public GameObject registerPanel;

    public void ActiveLoginPanel()
    {
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
    }

    public void ActiveRegisterPanel()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
    }

}
