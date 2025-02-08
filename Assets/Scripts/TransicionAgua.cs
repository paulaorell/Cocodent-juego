using UnityEngine;

public class TransicionEntrada : MonoBehaviour
{
    public Animator animacionCanvas; // Referencia al Animator del Canvas.

    void Start()
    {
        // Activa la animación de entrada al cargar la escena.
        animacionCanvas.SetTrigger("StartTransition");
    }
}
