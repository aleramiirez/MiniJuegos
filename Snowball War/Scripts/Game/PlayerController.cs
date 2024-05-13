using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /** Velocidad de movimiento del personaje **/
    public float moveSpeed;

    /** Fuerza de salto del personaje **/
    public float jumpForce;

    /** Tecla para moverse a la izquierda **/
    public KeyCode left;

    /** Tecla para moverse a la derecha **/
    public KeyCode right;

    /** Tecla para saltar **/
    public KeyCode jump;

    /** Tecla para lanzar una bola de neve **/
    public KeyCode shoot;

    /** Referencia al Rigidbody2D del objeto **/
    private Rigidbody2D rb;

    /** Variable Transform para saber si en la posicion del jugador esta tocando el suelo **/
    public Transform groundCheckPoint;

    /** Variable para dibujar un area imaginaria que determinara el espacio para saber si toca el suelo **/
    public float groundCheckRadius;

    /** Variable para saber si es el suelo lo que esta tocando **/
    public LayerMask whatIsGround;
    
    /** Booleano para indicar si esta tocando el suelo o no **/
    public bool isGrounded;
    
    /** Referencia al animator **/
    private Animator anim;

    /** Referencia a la bola de nieve **/
    public GameObject snowBall;

    /** Referencia al punto desde donde se lanzan las bolas de nieve **/
    public Transform throwPoint;

    /** Referencia al sonido de lanzar bolas de nieve **/
    public AudioSource throwSound;

    private void Start()
    {
        /** Encuentra el Rigidbody2D del objeto **/
        rb = GetComponent<Rigidbody2D>();

        /** Encuentra el Animator del objeto **/
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        /** Variable para saber si el personaje esta en el suelo **/
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);


        /** Si pulsa la tecla asignada a la variable left **/
        if (Input.GetKey(left))
        {
            /** Aplica la velocidad a la izquierda **/
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        /** Si pulsa la tecla asignada a la variable right **/
        else if (Input.GetKey(right))
        {
            /** Aplica la velocidad a la derecha **/
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        /** si deja de presionarlas se queda quieto **/
        else
        {
            /** Anula la velocidad del eje X **/
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        /** Si pulsa la tecla asignada a la variable jump y esta en el suelo **/
        if (Input.GetKey(jump) && isGrounded)
        {
            /** Aplica el salto al personaje **/
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        /** Si pulsa la tecla asignada a la variable shoot **/
        if (Input.GetKeyDown(shoot))
        {
            /** Crea la bola de nieve **/
            GameObject ballClone = (GameObject) Instantiate(snowBall, throwPoint.position, throwPoint.rotation);

            /** Direccion en la que se lanza la bola **/
            ballClone.transform.localScale = transform.localScale;

            /** Envia la informacion de lanzar al parametro del animator **/
            anim.SetTrigger("Throw");

            /** Activa el sonido de lanzar bolas de nieve **/
            throwSound.Play();
        }

        /** Si la velocidad es menor que 0 **/
        if (rb.velocity.x < 0)
        {
            /** El jugador mira a la izquierda **/
            transform.localScale = new Vector3(-1, 1, 1);
        } 
        
        /** Si la veloidad es mayor que cero **/
        else if (rb.velocity.x > 1)
        {
            /** El jugador mira a la derecha **/
            transform.localScale = new Vector3(1, 1, 1);
        }

        /** Envia la informacion de la velocidad al parametro del animator **/
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        /** Envia la informacion de si esta en el suelo al parametro del animator **/
        anim.SetBool("Grounded", isGrounded);
    }
}
