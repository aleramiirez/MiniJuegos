using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /** Referencia al texto de puntuacion **/
    public TextMeshProUGUI scoreText;

    /** Variable para la puntuacion **/
    private float score;

    /** Variable para el puntaje entero acumulado **/
    private int accumulatedScore = 0;

    /** Referencia al script LevelUpApi **/
    public LevelUpApi levelUpApi;

    private void Update()
    {
        /** Si el gameObject con etiqueta "Player" no es null **/
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            /** Va sumando uno por cada segundo **/
            score += 1 * Time.deltaTime;

            /** Convertir el puntaje en flotante a un entero **/
            int intScore = (int)score;

            /** Verificar si el puntaje entero ha aumentado **/
            if (intScore > accumulatedScore)
            {
                /** Actualizar el puntaje entero acumulado **/
                accumulatedScore = intScore;

                /** Editar el texto con la puntuacion actual **/
                scoreText.text = accumulatedScore.ToString();

                /** Verificar si el puntaje acumulado es múltiplo de 30 **/
                if (accumulatedScore % 30 == 0)
                {
                    levelUpApi.LevelUp();
                }
            }
        }
    }
}
