using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameModeEnemies : MonoBehaviour
{
    /** Referencia al script GameManagerFoxy **/
    public GameManagerFoxy manager;

    /** Matriz de enemies **/
    public GameObject[] enemies;

    /** Text de enemigos **/
    public TextMeshProUGUI enemiesText;

    private void Update()
    {
        /** Encuentra los enemigos que hay en la escena **/
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        /** El numero de enemigos almacenados es 0 **/
        if (enemies.Length == 0)
        {
            /**Llama a la funcion FinishLevel() **/
            manager.FinishLevel();
        }

        enemiesText.text = "x" + enemies.Length;
    }
}
