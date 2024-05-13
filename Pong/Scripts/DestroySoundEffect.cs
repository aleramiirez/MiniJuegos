using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySound : MonoBehaviour
{
    void Start()
    {
        /** 
         * Destruye el prefab del sonido de colision para que no 
         * se acumule y se realentize el juego 
         * **/
        Destroy(gameObject, 1);
    }
}
