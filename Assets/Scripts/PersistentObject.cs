using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

     void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verificar si la escena cargada es "MenuPrincipal"
        if (scene.name == "MenuPrincipal")
        {
            // Destruir el objeto persistente cuando se carga la escena MenuPrincipal
            Destroy(gameObject);
        }
    }
}