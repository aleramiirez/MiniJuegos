using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SearchUserApi : MonoBehaviour
{
    public string URL;
    public TMP_InputField usernameField; // Campo de entrada para el nombre de usuario a buscar
    public TMP_Text usernameText; // Texto para mostrar el nombre de usuario
    public TMP_Text levelText; // Texto para mostrar el nivel
    public GameObject searchPanel; // Panel de búsqueda
    public GameObject panelException; // Panel de excepciones
    public TextMeshProUGUI textException; // Texto para mostrar excepciones
    public Slider exceptionSlider; // Slider para la barra de progreso

    public void SearchUser()
    {
        StartCoroutine(GetUser());
    }

    private IEnumerator GetUser()
    {

        // Construir la URL completa con el nombre de usuario
        string url = $"{URL}/{usernameField.text}";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            // Enviar la solicitud y esperar la respuesta
            yield return request.SendWebRequest();


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
                UserDto user = JsonUtility.FromJson<UserDto>(request.downloadHandler.text);

                // Actualizar el UI con los datos obtenidos
                usernameText.text = "Username: " + user.username;
                levelText.text = "Level: " + user.level.ToString();
                searchPanel.SetActive(true);
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

// Clase para mapear la respuesta JSON de la API
[System.Serializable]
public class UserDto
{
    public string username;
    public int level;
}

// Clase para manejar respuestas de error
[System.Serializable]
public class ErrorResponseGetUser
{
    public string message;
}
