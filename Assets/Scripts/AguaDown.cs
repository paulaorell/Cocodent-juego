using UnityEngine;

public class AguaDown : MonoBehaviour
{
    public Animator animacionCanvas; // Referencia al Animator del Canvas.

    void Start()
    {
        // Activa la animación de entrada al cargar la escena.
        animacionCanvas.SetTrigger("StartTransition");
    }
}
