using UnityEngine;
using UnityEngine.SceneManagement;

public class AguaUp : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a la que cambiar.
    public GameObject canvas; // Canvas que se activará antes de la transición.
    public float delayBeforeTransition = 40f; // Tiempo antes de iniciar la animación.

    private Animator imageAnimator; // Animator del Canvas.

    void Start()
    {
        // Desactivar el Canvas al inicio.
        if (canvas != null) 
            canvas.SetActive(false);

        // Obtener el componente Animator del Canvas.
        imageAnimator = canvas.GetComponent<Animator>();

        // Llamar a la función para activar el Canvas después del tiempo especificado.
        Invoke("ActivateCanvas", delayBeforeTransition);
    }

    void ActivateCanvas()
    {
        // Activar el Canvas y la animación de transición.
        if (canvas != null) 
            canvas.SetActive(true);

        if (imageAnimator != null)
        {
            imageAnimator.SetTrigger("StartAnimation");
        }
    }

    // 📌 Este método será llamado por el evento en la animación.
    public void CambiarEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
