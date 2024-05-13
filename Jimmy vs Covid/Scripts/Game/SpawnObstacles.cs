using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    /** Referencia al obstaculo **/
    public GameObject obstacle;

    /** Rango en el que queremos que nuestros obstacuos se spawnen **/
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    /** Tiempo entre spawn **/
    public float timeBetweenSpawn;

    /** Tiempo en el que se generan los obstaculos **/
    private float spawnTime;

    private void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    /** Metodo para spawnear los obstaculos **/
    void Spawn()
    {
        /** Spawn random entre el rango asignado para el eje X **/
        float randomX = Random.Range(minX, maxX);

        /** Spawn random entre el rango asignado para el eje Y **/
        float randomY = Random.Range(minY, maxY);

        /** Creamos la instancia del obstaculo **/
        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
