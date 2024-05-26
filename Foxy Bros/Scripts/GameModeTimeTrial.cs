using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameModeTimeTrial : MonoBehaviour
{
    /** Referencia al script GameManagerFoxy **/
    public GameManagerFoxy manager;

    /** Duracion del nivel **/
    public float levelTimer = 300f;

    /** Text de tiempo **/
    public TextMeshProUGUI timeText;

    private void Update()
    {
        /** Si el tiempo es mayor que 0 **/
        if (levelTimer > 0)
        {
            /** Va restando segundos **/
            levelTimer = levelTimer - Time.deltaTime;
        }
        
        /** Si el tiempo es meno que 0 **/
        else
        {
            /** Si isGameOver es igual a false **/
            if (manager.isGameOver == false)
            {
                /** Establece el bool a true **/ 
                manager.isGameOver = true;

                /** Llama a la funcion Die() **/
                manager.player.Die();
            }
        }

        timeText.text = levelTimer.ToString("F1");
    }
}
