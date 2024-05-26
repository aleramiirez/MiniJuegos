using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /** Referencia a lo que la camara va a seguir **/
    public Transform target;

    /** Velocidad con la que la camara sigue al jugador **/
    public float speed = 0.5f;

    /** Variable para ajustar la posicion **/
    public Vector3 offset;

    private void LateUpdate()
    {
        /** Posicion en la que se desea mover **/
        Vector3 desiredPositon = target.position + offset;

        /** Sigue al jugador de manera suave **/
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPositon, speed);

        /** Bloquea la posicion y de la camara **/
        smoothPosition.y = 0f;

        /** Aplica el movimiento a la camara **/
        transform.position = smoothPosition;
    }
}
