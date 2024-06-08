using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginApi : MonoBehaviour
{
    public string URL;
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public GameObject loginPanel;
    public GameObject loadingPanel; // Panel de carga
    public GameObject panelException; // Panel de excepciones
    public TextMeshProUGUI textException; // Texto para mostrar excepciones
    public Slider exceptionSlider; // Slider para la barra de progreso

    public void Login()
    {
        StartCoroutine(LoginUser());
    }

    private IEnumerator LoginUser()
    {
        // Activar el panel de carga
        loadingPanel.SetActive(true);

        // Crear el objeto de datos de login
        LoginData loginData = new LoginData
        {
            username = usernameField.text,
            password = passwordField.text
        };

        // Convertir los datos de login a JSON
        string jsonData = JsonUtility.ToJson(loginData);

        // Crear la solicitud POST
        using (UnityWebRequest request = new UnityWebRequest(URL, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            // Enviar la solicitud y esperar la respuesta
            yield return request.SendWebRequest();

            // Desactivar el panel de carga
            loadingPanel.SetActive(false);

            if (request.responseCode != 200)
            {
                // Mostrar el mensaje de error de la respuesta de la API
                string errorResponse = request.downloadHandler.text;
                Debug.LogError("Error: " + errorResponse);
                ShowException(ParseErrorMessage(errorResponse));
            }
            else
            {
                // Procesar la respuesta
                Debug.Log("Response: " + request.downloadHandler.text);
                PlayerStatusLogin playerStat = JsonUtility.FromJson<PlayerStatusLogin>(request.downloadHandler.text);

                // Guardar los datos en PlayerPrefs
                PlayerPrefs.SetString("Username", playerStat.username);
                PlayerPrefs.SetInt("Nivel", playerStat.level);
                PlayerPrefs.Save();

                // Cargar la escena "Main Menu"
                SceneManager.LoadScene("Main Menu");
            }
        }
    }

    private void ShowException(string message)
    {
        textException.text = message;
        panelException.SetActive(true);
        StartCoroutine(HideExceptionPanelAfterDelay(5f)); // Inicia la coroutine para ocultar el panel después de 5 segundos
    }

    private IEnumerator HideExceptionPanelAfterDelay(float delay)
    {
        float elapsedTime = 0f;

        // Inicializar el valor del Slider
        exceptionSlider.maxValue = delay;
        exceptionSlider.value = delay;

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            exceptionSlider.value = delay - elapsedTime;
            yield return null;
        }

        panelException.SetActive(false); // Desactiva el panel de excepciones
    }

    private string ParseErrorMessage(string response)
    {
        // Intentar parsear el mensaje de error desde la respuesta JSON
        try
        {
            ErrorResponseLogin error = JsonUtility.FromJson<ErrorResponseLogin>(response);
            return error.message;
        }
        catch
        {
            return "Error desconocido";
        }
    }
}

// Clase para los datos de login
[System.Serializable]
public class LoginData
{
    public string username;
    public string password;
}

// Clase para el estado del jugador
[System.Serializable]
public class PlayerStatusLogin
{
    public string username;
    public int level;
}

// Clase para manejar respuestas de error
[System.Serializable]
public class ErrorResponseLogin
{
    public string message;
}
