using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    /** Musica de fondo **/
    private static Music music;

    void Awake()
    {
        /** Si musica es null no elimina la musica de fondo **/
        if (music == null)
        {
            music = this;
            DontDestroyOnLoad(music);
        }
        /** Si no elimina la musica **/
        else
        {
            Destroy(music);
        }

    }
}
