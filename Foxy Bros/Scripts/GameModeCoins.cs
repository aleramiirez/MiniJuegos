using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameModeCoins : MonoBehaviour
{
    /** Referencia al script GameManagerFoxy **/
    public GameManagerFoxy manager;

    /** Matriz de cherries **/
    public GameObject[] cherries;

    /** Text de cerezas **/
    public TextMeshProUGUI cherriesText;

    private void Update()
    {
        /** Encuentra las cerezas que hay en la escena **/
        cherries = GameObject.FindGameObjectsWithTag("Cherry");

        /** El numero de cerezas almacenados es 0 **/
        if (cherries.Length == 0)
        {
            /**Llama a la funcion FinishLevel() **/
            manager.FinishLevel();
        }

        cherriesText.text = "x" + cherries.Length;
    }
}
