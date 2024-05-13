using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script : MonoBehaviour
{
    /** Referencia al jugador 1 **/
    public GameObject player1;

    /** Referencia al jugador 2 **/
    public GameObject player2;

    /** Numero de vidas del jugador 1 **/
    public int player1Life;

    /** Numero de vidas del jugador 2 **/
    public int player2Life;

    /** Refrencia a la pantalla de Player1Win **/
    public GameObject player1Win;

    /** Refrencia a la pantalla de Player2Win **/
    public GameObject player2Win;

    /** Referencia a la matriz de bastones de caramelos del jugador 1 **/
    public GameObject[] p1CandyCanes;

    /** Referencia a la matriz de bastones de caramelos del jugador 2 **/
    public GameObject[] p2CandyCanes;

    /** Referencia al sonido del daño **/
    public AudioSource hurtSound;

    private void Update()
    {
        /** Si el jugador 1 tiene 0 vidas o menos **/
        if (player1Life <= 0)
        {
            /** Desactiva al jugador 1 **/
            player1.SetActive(false);

            /** Activa la panatalla de GameOver **/
            player2Win.SetActive(true);
        }

        /** Si el jugador 2 tiene 0 vidas o menos **/
        if (player2Life <= 0)
        {
            /** Desactiva al jugador 2 **/
            player2.SetActive(false);

            /** Activa la panatalla de GameOver **/
            player1Win.SetActive(true);
        }
    }

    /** Metodo para restar vidas al jugador 1 **/
    public void HurtP1()
    {
        /** Resta una vida al jugador 1 **/
        player1Life--;

        /** Itera sobre la matriz de bastones de caramelos **/
        for (int i = 0; i < p1CandyCanes.Length; i++)
        {
            /** Si el numero de vidas del jugador 1 es mayor que i **/
            if (player1Life > i)
            {
                /** Activa las imagenes de bastones de caramelos **/
                p1CandyCanes[i].SetActive(true);
            }

            /** Si no es mayor que i **/
            else
            {
                /** Desactiva las imagenes de bastones de caramelos **/
                p1CandyCanes[i].SetActive(false);
            }
        }

        /** Reproduce el sonido de daño **/
        hurtSound.Play();
    }

    /** Metodo para restar vidas al jugador 2 **/
    public void HurtP2()
    {
        /** Resta una vida al jugador 2 **/
        player2Life--;

        /** Itera sobre la matriz de bastones de caramelos **/
        for (int i = 0; i < p2CandyCanes.Length; i++)
        {
            /** Si el numero de vidas del jugador 2 es mayor que i **/
            if (player2Life > i)
            {
                /** Activa las imagenes de bastones de caramelos **/
                p2CandyCanes[i].SetActive(true);
            }

            /** Si no es mayor que i **/
            else
            {
                /** Desactiva las imagenes de bastones de caramelos **/
                p2CandyCanes[i].SetActive(false);
            }
        }

        /** Reproduce el sonido de daño **/
        hurtSound.Play();
    }

    /** Funcion para cargar la escena del juego **/
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /** Funcion para cargar el menu principal **/
    public void Exit()
    {
        SceneManager.LoadScene("Menu Snowball");
    }
}
