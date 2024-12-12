using UnityEngine;
using UnityEngine.SceneManagement; 

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent MusicPlayer from being destroyed on scene load
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2) // build index 2
        {
            GetComponent<AudioSource>().Stop(); // Stop the music
        }
    }
}
