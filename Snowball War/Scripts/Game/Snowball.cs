using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    /** Velocidad de la bola **/
    public float ballSpeed;

    /** Rferencia al RigidBody2D **/
    private Rigidbody2D rb;

    /** Referencia al efecto de la bola de nieve al destruirse **/
    public GameObject snowBallEffect;

    private void Start()
    {
        /** Encuentra el Rigidbody2D del objeto **/
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /** Aplica el movimiento a la bola segun la direccion del personaje **/
        rb.velocity = new Vector2(ballSpeed * transform.localScale.x, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        /** Si colisiona con un objeto con el tag "Player 1" **/
        if (collision.tag == "Player 1")
        {
            /** Encuentra el objeto GameManger y llama a la funcion HurtP1() **/
            FindObjectOfType<Script>().HurtP1();
        }

        /** Si colisiona con un objeto con el tag "Player 2" **/
        if (collision.tag == "Player 2")
        {
            /** Encuentra el objeto GameManger y llama a la funcion HurtP2() **/
            FindObjectOfType<Script>().HurtP2();
        }

        /** Crea el efecto de la bola de nieve cuando se destruye **/
        Instantiate(snowBallEffect, transform.position, transform.rotation);

        /** Destruye la bola de nieve al colisionar con cualquiero collider **/
        Destroy(gameObject);
    }
}
