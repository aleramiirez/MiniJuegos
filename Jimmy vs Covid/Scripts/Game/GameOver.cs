using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    /** Referencia al panel de Game Over **/
    public GameObject gameOverPanel;

    private void Update()
    {
        /** Si el gameObject con etiqueta "Player" es null **/
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            /** Activa el "gameOverPanel" **/
            gameOverPanel.SetActive(true);

            Time.timeScale = 0;
        }
    }

    /** Metodo para reiniciar la partida **/
    public void Restart()
    {
        /** Recarga la scena **/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu Jimmy vs Covid");
    }
}
