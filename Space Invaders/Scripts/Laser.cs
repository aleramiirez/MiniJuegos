using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    /** Direccion del laser **/
    public Vector3 direction;

    /** Velocidad del disparo **/
    public float speed;

    /** Evento de destruccion del laser **/
    public System.Action destroyed;

    private void Update()
    {
        /** Aplica el movimiento al objeto **/
        this.transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /** Si no esta destruido **/
        if (this.destroyed != null)
        {
            /** Invocacion del evento de destruccion del laser **/
            this.destroyed.Invoke();
        }

        /** Destruye el laser **/
        Destroy(this.gameObject);
    }
}
