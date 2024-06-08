using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxyController : MonoBehaviour
{
    /** Input del movimiento horizontal del jugador **/
    public float horizontalInput = 0f;

    /** Velocidad de movimiento **/
    public float speed = 10f;

    /** Referencia al script de FoxyMovement **/
    public FoxyMovement movement;

    /** Bool para saber si esta vivo **/
    public bool isAlive = true;

    /** Referencia al script GameManagerFoxy **/
    public GameManagerFoxy manager;

    /** Referencia al componente Animator **/
    public Animator anim;

    /** Referencia al componente AudioSource **/
    public AudioSource audioS;

    /** Referencia al sonido de monedas **/
    public AudioClip cherrySound;

    /** Referencia al sonido de monedas **/
    public AudioClip gemSound;

    /** Referencia al sonido de muerte **/
    public AudioClip hurtSound;

    /** Referencia al sonido de salto **/
    public AudioClip jumpSound;

    public LevelUpApi levelUpApi;

    void Update()
    {
        /** Iguala la variable al eje horizontal **/
        horizontalInput = Input.GetAxisRaw("Horizontal");

        /** Si pulsa el boton Jump y esta vivo **/
        if (Input.GetButtonDown("Jump") && isAlive)
        {
            /** Si esta en el suelo **/
            if (movement.grounded)
            {
                /** Acitva el trigger Jump **/
                anim.SetTrigger("Jump");
            }

            /** Reproduce el sonido **/
            audioS.PlayOneShot(jumpSound, 1f);

            /** Llama a la funcion Jump() **/
            movement.Jump();           
        }

        /** Se le da el valor al bool Grounded **/
        anim.SetBool("Grounded", movement.grounded);

        /** Se le da el valor al bool isAlive **/
        anim.SetBool("isAlive", isAlive);

        /** Si horizontalInput es igual a 0 **/
        if (horizontalInput == 0f)
        {
            /** Restablece la velocidad de la animacion a 1 **/
            anim.speed = 1f;

            /** Se le da el valor false al bool Move **/
            anim.SetBool("Move", false);
        }

        /** Si horizontalInput no es igual a 0 **/
        else
        {
            if (isAlive && movement.grounded)
            {
                /** Para que conforme se apriete el joystick vaya aumentando la velocidad de la animacion **/
                anim.speed = 1 * Mathf.Abs(horizontalInput);
            }
            /** Se le da el valor false al bool Move **/
            anim.SetBool("Move", true);
        }
    }

    private void FixedUpdate()
    {
        /** Si esta vivo **/
        if (isAlive)
        {
            /** Aplica el movimiento llamando a la función Move del script de FoxyMovement **/
            movement.Move(horizontalInput * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /** Si entra en un objeto llamado Cherry **/
        if (collision.gameObject.tag == "Cherry")
        {
            /** Destruye el objeto **/
            Destroy(collision.gameObject);

            /** Incrementa en 1 el total de monedas recogidas **/
            manager.totalCoins++;

            audioS.PlayOneShot(cherrySound, 1f);
        }

        /** Si entra en un objeto llamado Gem **/
        if (collision.gameObject.tag == "Gem")
        {
            /** Destruye el objeto **/
            Destroy(collision.gameObject);

            /** Incrementa en 1 el total de monedas recogidas **/
            manager.totalGems++;

            /** Si tiene menos de 3 vidas **/
            if (manager.lives < 3)
            {
                /** Suma una vida mas **/
                manager.lives++;
            }  

            /** Reproduce el sonido **/
            audioS.PlayOneShot(gemSound, 1f);
        }

        /** Si colisiona con un gameObject PoisonedCherry **/
        if (collision.gameObject.tag == "PoisonedCherry")
        {
            if (isAlive)
            {
                /** Destruye el objeto **/
                Destroy(collision.gameObject);

                /** Llama a la funcion Die() **/
                Die();
            }
        }

        /** Si entra en un objeto llamado CheckPoint **/
        if (collision.gameObject.tag == "CheckPoint")
        {
            /** Cambia su punto de spawn a ese punto nuevo **/
            manager.spawnPoint = collision.gameObject.transform;
        }

        /** Si entra en un objeto llamado LevelEnd **/
        if (collision.gameObject.tag == "LevelEnd")
        {
            /** Llama a la funcion FinishLevel **/
            manager.FinishLevel();

            /** Llama al metodo de subir de nivel de la api */
            levelUpApi.LevelUp();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /** Si colisiona con un gameObject Spikes o Enemy **/
        if (collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "PoisonedCherry")
        {
            /** Si isAlive es true **/
            if (isAlive)
            {
                /** Llama a la funcion Die() **/
                Die();
            }
        }

        /** Si colisiona con un gameObject WeakPoint **/
        if (collision.gameObject.tag == "WeakPoint")
        {
            /** Desactiva el BoxCollider del gameObject padre **/
            collision.transform.parent.GetComponent<BoxCollider2D>().enabled = false;

            /** Marca isAlive como false **/
            Destroy(collision.transform.parent.gameObject);
        }
    }

    /** Metodo para cuando muere el jugador **/
    public void Die()
    {
        /** Marca isAlive como false **/
        isAlive = false;

        /** Activa el trigger Die **/
        anim.SetTrigger("Die");

        /** Reproduce el sonido **/
        audioS.PlayOneShot(hurtSound, 1f);

        /** Aplica el movimiento llamando a la función Move del script de FoxyMovement **/
        movement.Move(0);
    }
}
