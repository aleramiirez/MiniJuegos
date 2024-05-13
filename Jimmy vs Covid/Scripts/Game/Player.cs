using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jimmy : MonoBehaviour
{
    /** Velocidad del jugador **/
    public float playerSpeed;

    /** Referencia al Rigidbody2D del objeto **/
    private Rigidbody2D rb;

    /** Direccion del jugador **/
    private Vector2 direction;

    private void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /** Coge la direccion del eje Y **/
        float directionY = Input.GetAxisRaw("Vertical");

        /** Asigna la direccion al vector y lo normaliza para asegurarse de que sea un movimiento consistente **/
        direction = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate()
    {
        /** Aplica el movimiento al presonaje **/
        rb.velocity = new Vector2(0, direction.y * playerSpeed);
    }
}
