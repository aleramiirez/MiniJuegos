using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    /** Velocidad del fondo **/
    public float backgroundSpeed;

    /** Referencia al componente Renderer del objeto **/
    public Renderer backgroundRenderer;

    private void Update()
    {
        /** Aplica el movimiento al fondo **/
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
}
