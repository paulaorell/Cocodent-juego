using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // Panel de pausa en la UI.
    public AudioSource backgroundAudio; // Arrastra aquí el AudioSource en el Inspector.
    public string reiniciarNivel; // Nombre de la siguiente escena.
    public string menuSceneName = "MenuPrincipal";

    private bool isPaused = false;

    void Start()
    {
        // Asegura que el panel esté oculto al inicio
        pausePanel.SetActive(false);
        
        // Verificar si el AudioSource no se ha asignado, y encontrarlo si es necesario
        if (backgroundAudio == null)
        {
            backgroundAudio = GameObject.FindWithTag("Music")?.GetComponent<AudioSource>();
        }

        // Asegurarse de que la música persista entre escenas (si es necesario)
        if (backgroundAudio != null && !backgroundAudio.gameObject.CompareTag("Music"))
        {
            DontDestroyOnLoad(backgroundAudio.gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded; // Se suscribe al evento cuando se carga una nueva escena.
    }
    // Se ejecuta cada vez que se carga una nueva escena
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Aseguramos que el panel de pausa esté oculto al cargar cualquier nivel
        pausePanel.SetActive(false);
            if (backgroundAudio == null)
            {
                backgroundAudio = GameObject.FindWithTag("Music")?.GetComponent<AudioSource>();
            }
        
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;

        // Pausa o reanuda el audio.
        if (backgroundAudio != null)
        {
            if (isPaused)
                backgroundAudio.Pause();
            else
                backgroundAudio.UnPause();
        }
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1f; // Restablece el tiempo antes de cambiar de nivel.
        
        if (backgroundAudio != null)
        {
            backgroundAudio.Stop(); // Detiene la música antes de cambiar de escena.
            backgroundAudio.Play(); // Reproduce el audio desde el principio.
        }

        SceneManager.LoadScene(reiniciarNivel); // Carga el nivel especificado en el Inspector.
        pausePanel.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Restablece el tiempo antes de cambiar de escena.

        if (SceneManager.GetActiveScene().name != menuSceneName)
        {
            GameObject musicObject = GameObject.FindWithTag("Music");
            if (musicObject != null)
            {
                Destroy(musicObject); // Destruye la música solo si vamos al menú.
            }
        }

        SceneManager.LoadScene(menuSceneName);
    }
}
