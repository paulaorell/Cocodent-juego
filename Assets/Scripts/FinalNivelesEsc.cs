using UnityEngine;

public class FinalNivelesEsc : MonoBehaviour
{
    public RhythmGameController rhythmGameController;
    public Canvas CanvasGano;  // Referencia al Canvas de cuando se gana
    public Canvas CanvasPerdio; // Referencia al Canvas de cuando se pierde

    void Start()
    {
        if (rhythmGameController == null)
        {
            rhythmGameController = FindObjectOfType<RhythmGameController>();
        }

        // Asegúrate de que los Canvas estén desactivados al iniciar
        if (CanvasGano != null) CanvasGano.gameObject.SetActive(false);
        if (CanvasPerdio != null) CanvasPerdio.gameObject.SetActive(false);
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
            // Activa el Canvas de "Perdido"
            if (CanvasPerdio != null) CanvasPerdio.gameObject.SetActive(true);
        }
        else
        {
            // Activa el Canvas de "Ganado"
            if (CanvasGano != null) CanvasGano.gameObject.SetActive(true);
        }
    }
}
