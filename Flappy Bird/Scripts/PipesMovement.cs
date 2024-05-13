using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    /** Velocidad a la que se mueven las tuberias **/
    public float speed = 5f;

    /** Representa el borde izquierdo de la pantalla **/
    private float leftBorder;

    private void Start()
    {
        /** Convierte de escaio de la pantalla a espacio mundial **/
        leftBorder = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        /** Aplica el movimiento a la tuberia **/
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftBorder )
        {
            Destroy(gameObject);
        }
    }
}
