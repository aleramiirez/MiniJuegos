using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips; // Array de clips de música para diferentes escenas
    public int[] scenesToKeepMusic; // Escenas donde la música no debe detenerse

    private static MusicManager instance = null;
    private AudioSource audioSource;
    private int currentSceneIndex = 0;

    void Awake()
    {
        // Si ya existe una instancia de MusicManager, destruye este objeto
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Asigna esta instancia y no la destruyas al cambiar de escena
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        // Suscribirse al evento de cambio de escena
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Desuscribirse del evento de cambio de escena
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // Obtener el índice de la nueva escena
        int newSceneIndex = scene.buildIndex;

        // Si la nueva escena está en la lista de escenas donde la música debe continuar, no hagas nada
        if (IsSceneInKeepMusicList(newSceneIndex))
        {
            currentSceneIndex = newSceneIndex;
            return;
        }

        // Si el índice de la escena ha cambiado, actualiza la música
        if (newSceneIndex != currentSceneIndex)
        {
            currentSceneIndex = newSceneIndex;

            // Si hay un clip de música para esta escena, reprodúcelo
            if (newSceneIndex < musicClips.Length && musicClips[newSceneIndex] != null)
            {
                audioSource.clip = musicClips[newSceneIndex];
                audioSource.Play();
            }
        }
    }

    // Método para verificar si una escena está en la lista de escenas donde la música debe continuar
    private bool IsSceneInKeepMusicList(int sceneIndex)
    {
        foreach (int index in scenesToKeepMusic)
        {
            if (index == sceneIndex)
                return true;
        }
        return false;
    }
}
