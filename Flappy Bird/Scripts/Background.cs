using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    /** Obtenemos una referencia del componente MeshRender del objeto **/
    private MeshRenderer meshRenderer;

    /** Velocidad a la que se va a mover el fondo **/
    public float animationBackgroundSpeed = 0.05f;

    private void Awake()
    {
        /** Busca el componente en el objeto en el que se ejecuta el script **/
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        /** Mueve el fondo **/
        meshRenderer.material.mainTextureOffset += new Vector2(animationBackgroundSpeed * Time.deltaTime, 0);
    }
}
