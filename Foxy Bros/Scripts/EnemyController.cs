using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /** Velocidad del enemigo **/
    public float speed = 2f;

    /** Distancia a recorrer **/
    public float distance = 3f;

    /** Posicion izquierda del recorrido **/
    private float positionLeft;

    /** Posicion derecha del recorrido **/
    private float positionRight;

    /** Posicion izquierda del recorrido **/
    private float positionUp;

    /** Posicion derecha del recorrido **/
    private float positionDown;

    /** Bool para saber si se esta moviendo hacia la derecha **/
    private bool isMovingRight = false;

    /** Bool para saber si se esta moviendo hacia la derecha **/
    private bool isMovingUp = false;

    /** Referencia al componente SpriteRenderer **/
    private SpriteRenderer spriteRenderer;

    /** Bool para saber si el movimiento es horizontal **/
    public bool horizontalMove;

    private void Start()
    {
        /** Busca el componente en la escena **/
        spriteRenderer = GetComponent<SpriteRenderer>();

        /** Calcula la posicion izquierda del recorrido **/
        positionLeft = transform.position.x - distance;

        /** Calcula la posicion derecha del recorrido **/
        positionRight = transform.position.x + distance;

        /** Calcula la posicion izquierda del recorrido **/
        positionDown = transform.position.y - distance;

        /** Calcula la posicion derecha del recorrido **/
        positionUp = transform.position.y + distance;
    }

    private void Update()
    {
        if (horizontalMove)
        {

            /** Si se esta moviendo hacia la derecha **/
            if (isMovingRight)
            {
                /** Aplica el movimiento al enemigo hacia la derecha **/
                gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

            /** Si se esta moviendo hacia la iaquierda **/
            else
            {
                /** Aplica el movimiento al enemigo hacia la izquierda **/
                gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            /** Si la posicion es mayor que el limite derecho **/
            if (transform.position.x > positionRight)
            {
                /** Voltea el personaje **/
                spriteRenderer.flipX = false;

                /** Establece el bool como false **/
                isMovingRight = false;
            }

            if (transform.position.x < positionLeft)
            {
                /** Voltea el personaje **/
                spriteRenderer.flipX = true;

                /** Establece el bool como true **/
                isMovingRight = true;
            }

        } 
        
        /** Si el movimiento no es horizontal **/
        else
        {
            /** Si se esta moviendo hacia arriba **/
            if (isMovingUp)
            {
                /** Aplica el movimiento al enemigo hacia arriba **/
                gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
            }

            /** Si se esta moviendo hacia abajo **/
            else
            {
                /** Aplica el movimiento al enemigo hacia la abajo **/
                gameObject.transform.Translate(Vector2.down * speed * Time.deltaTime);
            }

            /** Si la posicion es mayor que el limite derecho **/
            if (transform.position.y > positionUp)
            {
                /** Establece el bool como false **/
                isMovingUp = false;
            }

            if (transform.position.y < positionDown)
            {
                /** Establece el bool como true **/
                isMovingUp = true;
            }
        }
    }
}
