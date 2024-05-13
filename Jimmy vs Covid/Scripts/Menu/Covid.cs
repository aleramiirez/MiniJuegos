using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covid : MonoBehaviour
{
    /** Velocidad de movimiento **/
    public float speed = 2.0f; 

    /** Distancia del movimiento **/
    public float distance = 1.0f;
    
    /** Posicion inicial **/
    private Vector3 startPos; 

    void Start()
    {
        /** Guarda la posicion inicial **/
        startPos = transform.position; 
    }

    void Update()
    {
        /** Calcular el desplazamiento basado en el seno del tiempo **/
        float yOffset = Mathf.Sin(Time.time * speed) * distance;

        /** Actualizar la posición del objeto **/
        transform.position = startPos + new Vector3(0, yOffset, 0);
    }
}
