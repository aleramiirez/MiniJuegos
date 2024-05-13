using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invaders : MonoBehaviour
{
    /** Numero de filas **/
    public int rows = 5;

    /** Numero de columnas **/
    public int colums = 11;

    /** Referencia a Inader **/
    public Invader[] prefabs;

    /** Velocidad del movimiento **/
    public AnimationCurve speed;

    /** Prefab del misil **/
    public Laser laserPrefab;

    /** Direccion del movimiento **/
    private Vector3 direction = Vector3.right;

    /** Cantidad de muertes **/
    public int amountKilled {  get; private set; }

    /** Cantidad de invasores vivos **/
    public int amountAlive => totalInvaders - amountKilled;

    /** Cantidad total de invasores **/
    public int totalInvaders => this.rows * this.colums;

    /** Porcentaje de invasores muertos **/
    public float percentKilled => (float) this.amountKilled / (float) this.totalInvaders;

    /** Tiempo para disparar misiles **/
    public float missileAtackRate = 1.0f;

    /** Obtiene el borde izquierdo de la pantalla **/
    public Vector3 leftEdge;

    /** Obtiene el borde derecho de la pantalla **/
    public Vector3 rightEdge;

    private void Awake()
    {
        /** Itera sobre la variable de filas **/
        for (int row = 0; row < rows; row++)
        {
            /** Ancho total **/
            float width = 2.0f * (this.colums - 1);

            /** Alto total **/
            float heigh = 2.0f * (this.rows - 1);

            /** Obtiene el centro **/
            Vector2 center = new Vector2(-width / 2, -heigh / 2);

            /** Posicion en la fila **/
            Vector3 rowPosition = new Vector3(center.x, center.y + (row * 2.0f), 0);

            /** Itera sobre la variable de columnas **/
            for (int col = 0; col < colums; col++)
            {
                /** Instancia un objeto invader **/
                Invader invader = Instantiate(prefabs[row], this.transform);

                invader.kill += InvaderKill;

                /** Establece la posicion del invader en la fila determinada **/
                Vector3 position = rowPosition;

                /** Obtinene la posicion de la columna **/
                position.x += col * 2f;

                /** Iguala la posicion del invader con la variable position **/
                invader.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        /** Invoca la funcion MissileAttack() cada cierto tiempo **/
        InvokeRepeating(nameof(MissileAttack), missileAtackRate, missileAtackRate);
    }

    private void Update()
    {
        /** Aplica el movimiento **/
        this.transform.position += direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

        /** Recorre todos los objetos **/
        foreach (Transform invader in this.transform)
        {
            /** Si el objeto no esta activo en la jerarquia **/
            if (!invader.gameObject.activeInHierarchy)
            {
                /** Continua al siguinete **/
                continue;
            }

            /** Si la direccion es a la derecha y choca con el borde derecho de la pantalla **/
            if (direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.5f))
            {
                /** Llama al metodo AdvanceRow() **/
                AdvanceRow();
            }

            /** Si la direccion es a la izquierda y choca con el borde izquierdo de la pantalla **/
            else if (direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.5f))
            {
                /** Llama al metodo AdvanceRow() **/
                AdvanceRow();
            }
        }
    }

    /** Metodo que cambia la direccion de movimiento y avanza una fila **/
    public void AdvanceRow()
    {
        /** Cambia la direccion del movimiento **/
        direction.x *= -1.0f;

        /** Obtiene la fila actual **/
        Vector3 position = this.transform.position;

        /** Le resta uno a la posicion **/
        position.y -= 1.0f;

        /** Aplica la posicion modificada **/
        this.transform.position = position;
    }

    /** Metedo para disparar misiles **/
    private void MissileAttack()
    {
        /** Recorre todos los objetos **/
        foreach (Transform invader in this.transform)
        {
            /** Si el objeto no esta activo en la jerarquia **/
            if (!invader.gameObject.activeInHierarchy)
            {
                /** Continua al siguinete **/
                continue;
            }

            if (Random.value < (1.0f / (float) this.amountAlive))
            {
                /** Crea una instancia del prefab del misil **/
                Instantiate(this.laserPrefab, invader.position, Quaternion.identity);
                break;
            }
        }
    }

    /** Metodo que se llama al matar a un invasor **/
    private void InvaderKill()
    {
        amountKilled++;
    }
}
