using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /** Puntuacion del jugador **/
    private int score;

    /** Texto de puntuacion **/
    public TextMeshProUGUI scoreText;

    /** Boton de play **/
    public GameObject playButton;

    /** Imagen de GameOver **/
    public GameObject gameOver;

    /** Imagen de Get Ready **/
    public GameObject getReady;

    /** Referencia del jugador **/
    public Player player;

    /** Referencia al GameObject settingPanel **/
    public GameObject settingPanel;

    private void Start()
    {
        /** Llama a la funcion Pausa() **/
        Pause();
    }

    private void Awake()
    {
        /** Se asegura que el juego no se reproduzca a mas de 60 fotogramas ya que no es necesario **/
        Application.targetFrameRate = 60;

        /** Llama a la funcion Pause() **/
        Pause();
    }

    /** Reinicia la partida **/
    public void Play()
    {
        /** Iguala la puntuacion a 0 **/
        score = 0;

        /** Modifica el texto de puntuacion **/
        scoreText.text = score.ToString();

        /** Oculta el boton de play **/
        playButton.SetActive(false);

        /** Oculta la imagen de Game Over **/
        gameOver.SetActive(false);

        /** Oculta la imagen de Get Ready **/
        getReady.SetActive(false);

        /** Reanuda el tiempo del juego **/
        Time.timeScale = 1;

        /** Activa las funciones del jugador **/
        player.enabled = true;

        /** Encuentra todos los objetos "Pipes" **/
        PipesMovement[] pipes = FindObjectsOfType<PipesMovement>();

        /** Recorre el array de tuberias **/
        for (int i = 0; i < pipes.Length; i++)
        {
            /** Destroza los gameObject tuberias **/
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        /** Para el tiempo del juego **/
        Time.timeScale = 0;

        /** Desactiva las funciones del jugador **/
        player.enabled = false;
    }

    /** Aumenta la puntuacion del jugador **/
    public void IncreaseScore()
    {
        /** Incrementa en 1 la puntuacion **/
        score++;
        
        /** Modifica el texto de la puntuacion **/
        scoreText.text = score.ToString();
    }

    /** Finaliza la partida **/
    public void GameOver()
    {
        /** Muestra la imagen de Game Over **/
        gameOver.SetActive(true);

        /** Muestra el boton de jugar **/
        playButton.SetActive(true);

        /** Llama a la funcion Pause() **/
        Pause();
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingPanel.SetActive(false);
    }

}
