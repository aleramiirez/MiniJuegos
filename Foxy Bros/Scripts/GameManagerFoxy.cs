using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerFoxy : MonoBehaviour
{
    /** Numero de monedas recogidas **/
    public int totalCoins = 0;
    
    /** Numero de monedas recogidas **/
    public int totalGems = 0;

    /** Numero de vidas del jugador **/
    public int lives = 3;

    /** Punto de spawn **/
    public Transform spawnPoint;

    /** Referencia al script FoxyController **/
    public FoxyController player;

    /** Tiempo que tarda en respawnear ek personaje **/
    public float timeToRespawn = 2f;

    /** Contador **/
    private float timer = 0;

    /** Bool para saber si el jugador ha perdido **/
    public bool isGameOver = false;

    /** Bool para saber si el jugador ha llegado al final del juego **/
    public bool isLevelFinished = false;

    /** Texto de vidas **/
    public TextMeshProUGUI lifeText;

    public GameObject levelEndPanel;

    public TextMeshProUGUI levelEndText;

    private void Start()
    {
        /** Spawnea al jugador en el punto de spawn al empezar el juego **/
        player.transform.position = spawnPoint.transform.position;

        Time.timeScale = 1f;
    }

    private void Update()
    {
        /** Si el jugador no esta vivo **/
        if (!player.isAlive && !isGameOver)
        {
            /** Si el contador es menor al tiempo de respawn **/
            if (timer < timeToRespawn)
            {
                /** Empieza un contador **/
                timer = timer + Time.deltaTime;
            }

            /** Si el timer es mayor que el tiempo de respawn **/
            else
            {
                /** Si las vidas son mayor que 0 **/
                if (lives > 0)
                {
                    /** Resta una vida **/
                    lives--;

                    /** Spawnea al jugador en el punto de spawn **/
                    player.transform.position = spawnPoint.transform.position;

                    /** Establece el bool como true **/
                    player.isAlive = true;

                    /** Restablece a 0 el contador **/
                    timer = 0f;
                } 
                
                /** Si las vidas son menor que 0 **/
                else
                {
                    /** Establece el bool a true **/
                    isGameOver = true;
                }
            }
        }

        /** El jugador a perdido o se ha pasado el nivel **/
        if (isGameOver || isLevelFinished)
        {

            Time.timeScale = 0f;

            levelEndPanel.SetActive(true);

            if (isGameOver)
            {
                levelEndText.text = "GAME OVER";
            }

            if (isLevelFinished)
            {
                levelEndText.text = "FINISHED";
            }

            /** Si el jugador pulsa el escape **/
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Main Menu
            }
        }

        lifeText.text = "x" + lives;
    }

    /** Funcion para terminar un nivel **/
    public void FinishLevel()
    {
        /** Establece el bool a true **/
        isLevelFinished = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu Foxy Bros");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
