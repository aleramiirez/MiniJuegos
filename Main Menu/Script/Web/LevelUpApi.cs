using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LevelUpApi : MonoBehaviour
{
    public string levelUpURL; // URL de la API para subir de nivel

    public void LevelUp()
    {
        StartCoroutine(LevelUpUser());
    }

    private IEnumerator LevelUpUser()
    {
        // Obtener el nombre de usuario de PlayerPrefs
        string username = PlayerPrefs.GetString("Username", null);

        if (string.IsNullOrEmpty(username))
        {
            // Mostrar un error si no hay nombre de usuario guardado en PlayerPrefs
            Debug.LogError("No username found in PlayerPrefs.");
            yield break;
        }

        // Construir la URL completa con el nombre de usuario
        string url = $"{levelUpURL}/{username}";

        // Enviar una solicitud PUT vacía para subir de nivel al usuario
        using (UnityWebRequest request = UnityWebRequest.Put(url, ""))
        {
            // Enviar la solicitud y esperar la respuesta
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                // Mostrar el error en la consola
                Debug.LogError(request.error);
            }
            else
            {
                // Mostrar un mensaje de éxito en la consola
                Debug.Log("User level up successful.");

                // Procesar la respuesta como una cadena y convertirla a un entero
                int newLevel;
                if (int.TryParse(request.downloadHandler.text, out newLevel))
                {
                    PlayerPrefs.SetInt("Nivel", newLevel);
                    PlayerPrefs.Save();
                    Debug.Log($"New level: {newLevel}");
                }
                else
                {
                    Debug.LogError("Failed to parse the new level from response.");
                }
            }
        }
    }
}
