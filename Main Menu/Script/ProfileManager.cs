using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ProfileManager : MonoBehaviour
{
    public TextMeshProUGUI usernameText;

    public TextMeshProUGUI levelText;

    public Image profilePhoto;

    public GameObject photoPanel;

    public GameObject searchPanel;

    public GameObject userPanel;

    public GameObject inputSearchUser;

    public GameObject buttonSearchUser;

    public GameObject profilePanel;

    // Clave para guardar la ruta de la foto de perfil en PlayerPrefs
    private const string ProfilePhotoKey = "ProfilePhoto";

    void Start()
    {
        // Obtener los datos del usuario guardados en PlayerPrefs
        string username = PlayerPrefs.GetString("Username");
        int nivel = PlayerPrefs.GetInt("Nivel");

        // Mostrar los datos del usuario en los elementos de UI
        usernameText.text = "Username: " + username;
        levelText.text = "Level: " + nivel.ToString();

        // Cargar la foto de perfil guardada, si existe
        string profilePhotoPath = PlayerPrefs.GetString(ProfilePhotoKey);
        if (!string.IsNullOrEmpty(profilePhotoPath))
        {
            Sprite loadedPhoto = LoadPhoto(profilePhotoPath);
            if (loadedPhoto != null)
            {
                profilePhoto.sprite = loadedPhoto;
            }
        }
    }

    public void ChangeProfilePhoto(Sprite newPhoto)
    {
        // Guardar la nueva foto de perfil
        string profilePhotoPath = SavePhoto(newPhoto);
        PlayerPrefs.SetString(ProfilePhotoKey, profilePhotoPath);

        // Cambiar la imagen de perfil
        profilePhoto.sprite = newPhoto;
    }

    private string SavePhoto(Sprite photo)
    {
        // Obtener una ruta única para guardar la foto
        string filePath = GetUniqueFilePath();

        // Convertir la imagen a un formato adecuado para guardarla
        byte[] bytes = photo.texture.EncodeToPNG();

        // Guardar la imagen en el sistema de archivos local
        File.WriteAllBytes(filePath, bytes);

        // Devolver la ruta de la foto guardada
        return filePath;
    }

    private string GetUniqueFilePath()
    {
        // Generar un nombre de archivo único basado en la fecha y hora actual
        string fileName = "profile_photo_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

        // Obtener la ruta del directorio persistente de la aplicación
        string directoryPath = Application.persistentDataPath;

        // Combinar la ruta del directorio con el nombre de archivo para obtener la ruta completa
        return Path.Combine(directoryPath, fileName);
    }

    private Sprite LoadPhoto(string path)
    {
        // Verificar si el archivo existe
        if (File.Exists(path))
        {
            // Cargar los bytes de la imagen desde el archivo
            byte[] bytes = File.ReadAllBytes(path);

            // Crear una textura a partir de los bytes de la imagen
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);

            // Crear un sprite a partir de la textura
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

            // Devolver el sprite cargado
            return sprite;
        }
        else
        {
            Debug.LogWarning("Failed to load profile photo. File not found: " + path);
            return null;
        }
    }

    public void EditPhoto()
    {
        inputSearchUser.SetActive(false);
        buttonSearchUser.SetActive(false);
        photoPanel.SetActive(true);
    }

    public void ClosePhotoPanel()
    {
        photoPanel.SetActive(false);
        inputSearchUser.SetActive(true);
        buttonSearchUser.SetActive(true);
    }

    public void Exit()
    {
        profilePanel.SetActive(false);
    }

    public void CloseSearchPanel()
    {
        searchPanel.SetActive(false);
        userPanel.SetActive(true);
    }

    public void GoLogin()
    {
        SceneManager.LoadScene("Login");
    }
}
