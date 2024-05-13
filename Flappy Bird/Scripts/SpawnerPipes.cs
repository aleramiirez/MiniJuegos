using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipes : MonoBehaviour
{
    /** Referencia al prefab de tuberias **/
    public GameObject prefab;

    /** Rango de spawn de tuberias **/
    public float spawnRate = 1f;

    /** Altura maxima de spawn de la tuberia **/
    public float minHeiht = -1f;

    /** Altura maxima de spawn de la tuberia **/
    public float maxHeiht = 1f;

    /** Metodo iniciar el spawn de tuberias **/
    private void OnEnable()
    {
        /** Invoca repetidas veces esa funcion **/
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        /** Cancela la invocacion repetida **/
        CancelInvoke(nameof(Spawn));
    }

    /* Metodo para spawnear las tuberias **/
    private void Spawn()
    {
        /** Crea una instancia del prefab **/
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        /** Controla la altura a la que se generan las tuberias **/
        pipes.transform.position += Vector3.up * Random.Range(minHeiht, maxHeiht);
    }
}
