using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalNivelesEsc : MonoBehaviour
{
    public RhythmGameController rhythmGameController;

    void Start()
    {
        if (rhythmGameController == null)
        {
            rhythmGameController = FindObjectOfType<RhythmGameController>();
        }
    }

    public void VerificarPuntajeFinal()
    {
        if (rhythmGameController == null)
        {
            Debug.LogError("RhythmGameController no encontrado en la escena.");
            return;
        }

        float score = rhythmGameController.ObtenerPuntaje();
        Debug.Log("Puntaje final obtenido: " + score);

        if (score < 20)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene("Gano");
        }
    }
}
