using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCode : MonoBehaviour
{
    /** Velocidad del jugador **/
    public float speed = 5.0f;

    /** Referencia al prefab del laser **/
    public Laser laserPrefab;

    /** Variable para saber si el laser esta activo **/
    private bool laserActive;

    /** Obtiene el borde izquierdo de la pantalla **/
    public Vector3 leftEdge;

    /** Obtiene el borde derecho de la pantalla **/
    public Vector3 rightEdge;

    private void Update()
    {
        /** Si el jugador presiona la tecla A o la flecha izquierda **/
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > leftEdge.x + 1.5f)
        {
            /** Aplica el movimiento a la izquierda **/
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }

        /** Si el jugador presiona la tecla D o la flecha derecha **/
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < rightEdge.x - 1.5f)
        {
            /** Aplica el movimiento a la derecha **/
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        /** Si presiona el espacio o el click izquierdo del raton **/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /** Llama a la funcion Shoot() **/
            Shoot();
        }
    }

    /** Metodo para disparar un laser **/
    public void Shoot()
    {
        if (!laserActive)
        {
            /** Instancia un objeto laser **/
            Laser laser = Instantiate(laserPrefab, this.transform.position, Quaternion.identity);

            laser.destroyed += LaserDestroyed;

            /** Activa al laser **/
            laserActive = true;
        }
    }

    /** Metodo para desactivar el laser **/
    private void LaserDestroyed()
    {
        /** Desactiva el laser **/
        laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /** Si colisiona con un un invasor o un misil **/
        if (collision.gameObject.layer == LayerMask.NameToLayer("Invader") ||
            collision.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
