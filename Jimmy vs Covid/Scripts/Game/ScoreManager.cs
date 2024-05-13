using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /** Referencia al texto de puntuacion **/
    public TextMeshProUGUI scoreText;

    /** Variable para la puntuacion **/
    private float score;

    private void Update()
    {
        /** Si el gameObject con etiqueta "Player" no es null **/
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            /** Va sumando uno por cada segundo **/
            score += 1 * Time.deltaTime;

            /** Edita el texto con la puntuacion actual **/
            scoreText.text = ((int) score).ToString();
        }
    }
}
