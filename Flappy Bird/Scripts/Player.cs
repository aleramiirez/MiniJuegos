using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /** Declaramos una variable del componente SpriteRenderer **/
    private SpriteRenderer spriteRender;

    /** Matriz de sprites **/
    public Sprite[] sprites;

    /** Variable que lleva el seguimiento del indice de la matriz de sprites **/
    private int spriteIndex;

    /** Direccion del jugador **/
    private Vector3 direction;

    /** Gravedad que afecta al jugador **/ 
    public float gravity = -9.8f;

    /** Fuerza con la que se mueve el jugador **/
    public float strenght = 5f;

    private void Start()
    {
        /** Invoca repetidas veces esa funcion **/
        InvokeRepeating(nameof(AnimatedSprite), 0.15f, 0.15f);
    }

    private void Awake()
    {
        /** Busca el componente en el objeto en el que se ejecuta el script **/
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        /** Crea un vector para la posicion **/
        Vector3 position = transform.position;

        /** Reinicia la posicion a 0 en el eje Y **/
        position.y = 0f;

        /** Restablece la posicion al jugador **/
        transform.position = position;

        /** Restablece la direccion **/
        direction = Vector3.zero;
    }

    private void Update()
    {
        /** Si presiona el espacio o el click izquierdo **/
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            /** Aplica la direccion al jugador **/
            direction = Vector3.up * strenght;
        }

        /** Si toca la pantalla del movil **/
        if (Input.touchCount > 0)
        {
            /** Coge la referencia al primer toque **/
            Touch touch = Input.GetTouch(0);

            /** Si acabas ded tocar la pantalla **/
            if (touch.phase == TouchPhase.Began)
            {
                /** Aplica la direccion **/
                direction = Vector3.up * strenght;
            }
        }

        /** Aplicamos la gravedad y la direccion **/
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    /** Aplica la animacion al personaje **/
    private void AnimatedSprite()
    {
        /** Incrementa en 1 el indice de la matriz de sprites **/
        spriteIndex++;

        /** Si llega al ultimo indice se le asigna otra vez 0 **/
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        /** Asigna el sprite al componente SpriteRender **/
        spriteRender.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /** Si entra en un objeto con la etiqueta "Obstacle" **/
        if (collision.gameObject.tag == "Obstacle")
        {
            /** Encuentra el objeto "GameManager" y llama al metodo GameOver() **/
            FindObjectOfType<GameManager>().GameOver();
        } 
        
        /** Si entra en un objeto con la etiqueta "Scoring" **/
        else if (collision.gameObject.tag == "Scoring")
        {
            /** Encuentra el objeto "GameManager" y llama al metodo IncreaseScore() **/
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
