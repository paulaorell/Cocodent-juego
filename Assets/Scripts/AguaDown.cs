using UnityEngine;

public class AguaDown : MonoBehaviour
{
    public Animator animacionCanvas; // Referencia al Animator del Canvas.

    void Start()
    {
        // Activa la animaci�n de entrada al cargar la escena.
        animacionCanvas.SetTrigger("StartTransition");
    }
}
