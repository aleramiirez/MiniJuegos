using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    /** Velocidad a la que se movera la camara **/
    public float cameraSpeed;

    private void Update()
    {
        /** Aplicamos el movimiento a la camara **/
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}
