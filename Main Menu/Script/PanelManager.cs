using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject loginPanel;

    public GameObject registerPanel;

    public void OpenLoginPanel()
    {
        registerPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void OpenRegisterPanel()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
    }
}
