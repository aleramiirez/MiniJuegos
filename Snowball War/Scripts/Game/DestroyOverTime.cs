using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    /** Tiempo de vida **/
    public float lifeTime;

    private void Update()
    {
        /** Reduce lifeTime en segundos **/
        lifeTime -= Time.deltaTime;

        /** Si lifeTime es menor a 0 **/
        if (lifeTime < 0)
        {
            /** Destruye el gameObject **/
            Destroy(gameObject);
        }
    }
}
