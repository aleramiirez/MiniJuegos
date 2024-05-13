using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    /** Velocidad inicial de la bola **/
    public float startSpeed;

    /** Variable para definir el incremento de la velocidad de la bola **/
    public float extraSpeed;

    /** Velocidad maxima de la bola **/
    public float maxExtraSpeed;

    /** Variable para ver si empieza el jugador 1 **/
    public bool player1Start = true;

    /** Contador de colisiones de la bola **/
    private int hintCount = 0;

    /** Elemento RigidBody **/
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
        
    }

    private void RestartBall()
    {
        /** Se cancela el movimiento **/
        rb.velocity = new Vector2(0, 0);

        /** Se reinicia la bola a su posicion inicial **/
        transform.position = new Vector2(0, 0);
    }

    /** Creamos una Coroutine donde iniciamos el movimiento de la bola **/
    public IEnumerator Launch()
    {
        /** Se llama a la funcion RestartBall() **/
        RestartBall();

        /** Inicializa el contador de colisiones de la bola en 0 **/
        hintCount = 0;

        /** Espera 1 segundo antes de hacer el movimiento de la bola **/
        yield return new WaitForSeconds(1);

        if (player1Start)
        {
            /** Se llama a la funcion MoveBall() **/
            MoveBall(new Vector2(-1, 0));
        } else
        {
            /** Se llama a la funcion MoveBall() **/
            MoveBall(new Vector2(1, 0));
        }
    }

    /** Metodo para definir el movimiento de la bola **/
    public void MoveBall(Vector2 direction)
    {
        /** Direccion de la bola **/
        direction = direction.normalized;

        /** Velocidad actual de la bola **/
        float ballSpeed = startSpeed + hintCount * extraSpeed;

        /** Aplica la velocidad a la bola **/
        rb.velocity = direction * ballSpeed;
    }

    /** Metodo para incrementar el contador de colisiones **/
    public void IncreaseHitCounter()
    {
        /** Si la velocidad de la bola es inferior a la maxima se incrementa el contador en 1 **/
        if (hintCount * extraSpeed < maxExtraSpeed)
        {
            hintCount++;
        } 
    }
}
