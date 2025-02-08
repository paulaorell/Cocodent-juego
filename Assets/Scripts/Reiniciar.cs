using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    private string escenaAnterior;
    
    void Start()
    {
        // Guarda la escena anterior antes de cargar Game Over
        escenaAnterior = PlayerPrefs.GetString("UltimaEscena", "Nivel1");
    }

    public void ReiniciarNivel()
    {
        // Dependiendo de la escena anterior, carga la escena correcta
        switch (escenaAnterior)
        {
            case "Nivel1":
                SceneManager.LoadScene("CocoCome");
                break;
            case "Nivel2":
                SceneManager.LoadScene("CocoMilo");
                break;
            case "Nivel3":
                SceneManager.LoadScene("CocoRodri");
                break;
            default:
                Debug.LogWarning("No se encontró la escena anterior, cargando Nivel1 por defecto.");
                SceneManager.LoadScene("CocoCome");
                break;
        }
    }

    public static void GuardarEscenaActual()
    {
        // Guarda la escena actual antes de cambiar a Game Over
        PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }
}