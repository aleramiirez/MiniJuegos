using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    /** Velocidad de la raqueta **/
    public float racketSpeed;

    /** Elemento RigidBody **/
    private Rigidbody2D rb;

    /** Direccion de la raqueta **/
    private Vector2 racketDirection;

    public KeyCode up;

    public KeyCode down;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        /** Direccion en el eje y **/
        float directionY = 0f;

        /** Verifica si se presiona la tecla hacia arriba **/
        if (Input.GetKey(up))
        {
            directionY = 1f;
        }

        /** Verifica si se presiona la tecla hacia abajo **/
        else if (Input.GetKey(down))
        {
            directionY = -1f;
        }

        /** Direccion de la raqueta en los ejes X,Y **/
        racketDirection = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate()
    {
        /** Aplica el movimiento a la raqueta **/
        rb.velocity = racketDirection * racketSpeed;
    }
}
