using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a la que deseas cambiar.

    void Start()
    {
        // Llama al método CambiarEscena después de 50 segundos.
        Invoke("CambiarEscena", 50f);
    }

    void CambiarEscena()
    {
        // Cambia a la escena especificada.
        SceneManager.LoadScene(nombreEscena);
    }
}
