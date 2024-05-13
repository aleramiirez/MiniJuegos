using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    /**Referencia al personaje **/
    private GameObject player;

    private void Start()
    {
        /** Encuentra el personaje en la escena **/
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /** Si choca con un objeto con la etiqueta "Border" **/
        if (collision.tag == "Border")
        {
            /** Destruye el objeto que lleva el script **/
            Destroy(this.gameObject);
        }

        /** Si choca un un objeto con la etiqueta personaje **/
        else if (collision.tag == "Player")
        {
            Destroy(player.gameObject);
        }
    }
}
