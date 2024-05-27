using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    /** Referenciia al servidor **/
    public Server server;

    /** Input del nombre de usuario **/
    public TMP_InputField inputUsername;

    /** Input de la contraseña **/
    public TMP_InputField inputPassword;

    /** Referencia al GameObject de opantalla de carga **/
     public GameObject loadingPanel;

    /** Referencia a un usuario de la bse de datos **/
    public DB_Users user;

    /** Metodo para realizar el login **/
    public void DoLogin()
    {
        StartCoroutine(StartLogin());
    }

    IEnumerator StartLogin()
    {
        /** Activa la pantalla de carga **/
        loadingPanel.SetActive(true);

        /** Crea una matriz de datos **/
        string[] data = new string[2];

        /** Establece el dato 1 como el nombre de usuario **/
        data[0] = inputUsername.text;

        /** Establece el dato 2 como la contraseña **/
        data[1] = inputPassword.text;

        /** Empieza una coroutine y llama al metodo UseService() **/
        StartCoroutine(server.UseService("Login", data, PostCharge));

        /** Espera 0.5 segundos **/
        yield return new WaitForSeconds(.5f);

        /** Espera al que el servidor no este ocupado **/
        yield return new WaitUntil(() => !server.inUse);

        /** Desactiva la pantalla de carga **/
        loadingPanel.SetActive(false);

    }

    public void PostCharge()
    {
        switch (server.response.codigo)
        {
            case 204: /** El usuario o la contraseña son incorrectos **/
                print(server.response.mensaje);
                break;
            case 205: /** Inicio de sesión correcto **/
                SceneManager.LoadScene("Main Menu");

                user = JsonUtility.FromJson<DB_Users>(server.response.respuesta);

                PlayerPrefs.SetString("Username", user.username);
                PlayerPrefs.SetInt("Nivel", user.nivel);

                break;
            case 402: /** Faltan datos para ejecutar la acción solicitada **/
                print(server.response.mensaje);
                break;
            case 404: /** Error **/
                print("Error, no se puede conectar el servidor");
                break;
            default: break;
        }
    }

    public string getUsername()
    {
        return user.username;
    }

    public string getLevel()
    {
        return user.nivel.ToString();
    }
}
