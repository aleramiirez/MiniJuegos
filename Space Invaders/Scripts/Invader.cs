using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    /** Referencia a la lista de sprites para las animaciones **/
    public Sprite[] animationSprites;

    /** Timepo que tarda en pasar al siguiente sprite de la lista **/
    public float animationTime = 1.0f;

    /** Referencia al SpriteRenderer del objeto **/
    private SpriteRenderer spriteRenderer;

    /** Variable para saber el sprite de la lista que esta seleccionado **/
    private int animationFrame;

    /** Evento de muerte de un invasor **/
    public System.Action kill;


    private void Awake()
    {
        /** Obtenemos el SpriteRenderer del objeto **/
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        /** Invoca repetidas veces a AnimateSprite() cada cierto tiempo dado por la variable animationTime **/
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    private void AnimateSprite()
    {
        /** Suma uno al animationFrame **/
        animationFrame++;

        /** Si animationFrame es mayor que la medida de la lista de animationSprites **/
        if (animationFrame >= animationSprites.Length)
        {
            /** Restablece a 0 animationFrame **/
            animationFrame = 0;
        }

        /** Obtiene el sprite que debe tener el objeto **/
        spriteRenderer.sprite = animationSprites[animationFrame];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /** Si colisiona con un laser **/
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            /** Invocacion del evento de muerte de un invasor **/
            this.kill.Invoke();

            /** Desactiva el invasor **/
            this.gameObject.SetActive(false);
        }
    }
}
