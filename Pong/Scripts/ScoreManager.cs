using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManagerPong : MonoBehaviour
{
    /** Puntuacion maxima **/
    public int scoreToReach;

    /** Puntuacion del jugador 1 **/
    private int player1Score = 0;

    /** Puntuacion del jugador 2 **/
    private int player2Score = 0;

    /** Texto de puntuacion del jugador 1 **/
    public TextMeshProUGUI player1ScoreText;

    /** Texto de puntuacion del jugador 2 **/
    public TextMeshProUGUI player2ScoreText;

    public void Player1Goal()
    {
        /** Incrementa en 1 la puntuacion **/
        player1Score++;

        /** Transforma la puntuacion del jugador a un texto **/
        player1ScoreText.text = player1Score.ToString();

        /** Llama a la funcion CheckScore **/
        CheckScore();
    }
    
    public void Player2Goal()
    {
        /** Incrementa en 1 la puntuacion **/
        player2Score++;

        /** Transforma la puntuacion del jugador a un texto **/
        player2ScoreText.text = player2Score.ToString();

        /** Llama a la funcion CheckScore **/
        CheckScore();
    }

    private void CheckScore()
    {
        /** Si el jugador 1 o 2 llega al limire de punto carga la pantalla final **/
        if (player1Score == scoreToReach || player2Score == scoreToReach)
        {
            SceneManager.LoadScene("Game Over Pong");
        }
    }
}
