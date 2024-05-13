using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{

    /** Referencia al script Invaders **/
    private Invaders invadersScript;

    private void Start()
    {
        /** Busca el script Invaders en la escena **/
        invadersScript = FindObjectOfType<Invaders>();
    }

    private void Update()
    {
        /** Si no quedan invasores vivos **/
        if (invadersScript.amountAlive == 0)
        {
            /** Elimina los bunkers **/
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /** Si los invasores tocan el objeto **/
        if (collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
                gameObject.SetActive(false);
        }
    }
}
