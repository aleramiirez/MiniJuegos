using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    /** Prefab del misil **/
    public Laser laserPrefab;

    /** Velocidad de movimiento **/
    public float speed;

    /** Direccion del movimiento **/
    private Vector3 direction = Vector3.right;

    /** Numero de vidas **/
    public int life = 5;

    /** Referencia al script Invaders **/
    private Invaders invadersScript;

    /** Tiempo entre cada disparo **/
    private float timeBetweenShots = 1.0f;

    /** Temporizador para controlar el tiempo entre disparos **/
    private float shotTimer;

    /** Obtiene el borde izquierdo de la pantalla **/
    public Vector3 leftEdge;

    /** Obtiene el borde derecho de la pantalla **/
    public Vector3 rightEdge;

    public GameObject startMenu;

    public LevelUpApi levelUpApi;

    private void Start()
    {
        /** Busca el script Invaders en la escena **/
        invadersScript = FindObjectOfType<Invaders>();

        /** Inicializa el temporizador de disparo **/
        shotTimer = timeBetweenShots;
    }

    private void Update()
    {
        /** Verifica si todos los invasores han sido eliminados **/
        if (invadersScript.amountAlive == 0)
        {
            /** Aplica el movimiento del jefe **/
            this.transform.position += direction * this.speed * Time.deltaTime;

            /** Si la dirección es a la derecha y choca con el borde derecho de la pantalla **/
            if (direction == Vector3.right && transform.position.x >= (rightEdge.x - 2.5f))
            {
                /** Cambia de dirección **/
                direction.x *= -1.0f;
            }
            /** Si la dirección es a la izquierda y choca con el borde izquierdo de la pantalla **/
            else if (direction == Vector3.left && transform.position.x <= (leftEdge.x + 2.5f))
            {
                /** Cambia de dirección **/
                direction.x *= -1.0f;
            }

            /** Actualiza el temporizador de disparo **/
            shotTimer -= Time.deltaTime;

            /** Si el temporizador llega a cero, dispara y reinicia el temporizador **/
            if (shotTimer <= 0)
            {
                MissileAttack();
                shotTimer = timeBetweenShots;
            }
        }
    }

    private void MissileAttack()
    {
        /** Crea una instancia del prefab del misil **/
        Laser laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

        /** Ajusta la escala del proyectil **/
        laser.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /** Verifica si todos los invasores han sido eliminados **/
        if (invadersScript.amountAlive == 0)
        {
            /** Si colisiona con un láser **/
            if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
            {
                /** Resta una vida al jefe **/
                life--;

                /** Desactiva el láser **/
                Destroy(collision.gameObject);

                /** Si el jefe se queda sin vidas, se desactiva **/
                if (life <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                    levelUpApi.LevelUp();
                }
            }
        }
    }
}
