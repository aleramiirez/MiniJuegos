using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxyMovement : MonoBehaviour
{
    /** Fueza de salto **/
    [SerializeField]
    private float jumpForce = 400f;
    
    /** Suaviza el movimiento para que se vea fluido **/
    [Range(0, .3f)]
    [SerializeField]
    private float movementSmoothing = .05f;
    
    [SerializeField]
    private bool airControl = false;
    
    /** Referencia a la capa del suelo **/
    [SerializeField]
    private LayerMask whatIsGround;
    
    /** Posicion para saber si esta en el suelo **/
    [SerializeField]
    private Transform groundCheck;
    
    /** Radio del circulo que determina si esta en el suelo **/
    const float groundedRadius = .2f;
    
    /** Bool que determina si el jugador esta en el suelo **/
    public bool grounded;
    
    /** Radio del circulo que determina si el jugador puede levantarse **/
    const float ceilingRadius = .2f;
    
    /** Referencia al Rigidbody2D **/
    private Rigidbody2D rb;
    
    /** Determina hacia donde esta mirando el jugador **/
    private bool facingRight = true;
    
    /** Velocidad de movimiento **/
    private Vector3 velocity = Vector3.zero;
    
    private void Awake()
    {
        /** Obtiene el componente Rigidbody2D **/
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        /** Bool para saber si esta en el suelo **/
        bool wasGrounded = grounded;

        /** Iguala el bool a false **/
        grounded = false;
        
        /** Si el groundedRadius golpea cualquier cosa designada como suelo marca que el jugador esta en el suelo **/
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);

        /** Itera sobre la matriz de colliders **/
        for (int i = 0; i < colliders.Length; i++)
        {
            /** Si el jugador colisiona con otro gameObject **/
            if (colliders[i].gameObject != gameObject)
            {
                /** Marca grounded como true **/
                grounded = true;
            }
        }
    }
    
    /**
     * Metodo que mueve al jugador en una direccion determinada
     * 
     * <param name="move"></param>
     **/
    public void Move(float move)
    {
        /** Solo controla al jugador si grounded o airControl son true **/
        if (grounded || airControl)
        {
            /** Mueve al personaje **/
            Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
            
            /** Aplica la velocidad al personaje y suaviza el mmovimiento **/
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

            /** Si se mueve el jugador a la derecha y esta mirando a la izquierda **/
            if (move > 0 && !facingRight)
            {
                /** Llama a la funcion Flip() **/ 
                Flip();
            }

            /** Si se mueve el jugador a la izquierda y esta mirando a la derecha **/
            else if (move < 0 && facingRight)
            {
                /** Llama a la funcion Flip() **/
                Flip();
            }
        }
    }
    
    /** Metodo que da la vuelta al jugador **/
    private void Flip()
    {
        /** Cambia la etiqueta del jugador **/
        facingRight = !facingRight;

        /** Obtiene la escala del jugador **/
        Vector3 theScale = transform.localScale;

        /** Multiplica la escala por -1 para revertirlo **/
        theScale.x *= -1;

        /** Aplica la escala al jugador **/
        transform.localScale = theScale;
    }
    
    /** Metodo para saltar **/
    public void Jump()
    {
        /** Si ground es true **/
        if (grounded)
        {
            /** Marca grounded como false **/
            grounded = false;

            /** Añade la fuerza hacia arriba para saltar **/
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }
}
