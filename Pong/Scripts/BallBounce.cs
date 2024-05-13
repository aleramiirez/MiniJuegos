using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    /** Sonido de la bola al colisionar **/
    public GameObject hitSound;

    /** Referencia al script de movimiento para la funcion de colision de la bola **/
    public BallMovement ballMovement;

    /** Referencia al script de puntuacion **/
    public ScoreManagerPong scoreManager;

    /** Metodo para el rebote de la bola **/
    private void Bounce(Collision2D collision)
    {
        /** Obtener la posicion de la bola **/
        Vector3 ballPosition = transform.position;

        /** Obtiene la posicion del objeto con el que nuestra bola choco **/
        Vector3 racketPosition = collision.transform.position;

        /** Obtiene la parte de la raqueta en la que golpeo la bola **/
        float racketHeight = collision.collider.bounds.size.y;

        /** Posicion en el eje X para saber con que jugador colisiona **/
        float positionX;

        if (collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        } else
        {
            positionX = -1;
        }

        /** Posicion en el eje Y **/
        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /** Si colisiona con las raquetas se le aplica el rebote **/
        if (collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            Bounce(collision);
        }

        /** 
         * Si colisiona con el lado derecho se llama a la funcion Player1Goal(),
         * asigna el valor false a la variable player1Start y inicia la coroutine 
         * para que la bola se reinicie 
         * **/
        else if (collision.gameObject.name == "Right Border")
        {
            scoreManager.Player1Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }

        /** 
         * Si colisiona con el lado izquierdo se llama a la funcion Player2Goal(),
         * asigna el valor true a la variable player2Start y inicia la coroutine 
         * para que la bola se reinicie 
         * **/
        else if (collision.gameObject.name == "Left Border")
        {
            scoreManager.Player2Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }

        /** Aplica el sonido siempre que colisiona la bola **/
        Instantiate(hitSound, transform.position, transform.rotation);
    }
}
