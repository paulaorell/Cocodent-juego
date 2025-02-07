using UnityEngine;

public class Transicion : MonoBehaviour
{
    public GameObject emptyObject1; // Objeto que aparecerá después de 40 segundos
    public GameObject emptyObject2; // Objeto que aparecerá cuando se active el evento de la animación
    public GameObject canvas; // Canvas que estará desactivado al inicio
    public float delayBeforeAppearance = 40f; // Tiempo en segundos antes de que aparezca el primer objeto

    private Animator imageAnimator; // Animator de la imagen

    void Start()
    {
        // Desactivar el canvas y emptyObject2 al inicio
        if (canvas != null) canvas.SetActive(false);
        emptyObject2.SetActive(false);

        // Activar emptyObject1 al inicio
        emptyObject1.SetActive(true);

        // Obtener el componente Animator del objeto con la imagen
        imageAnimator = GetComponent<Animator>();

        // Llamar a la función para activar el Canvas después del tiempo especificado
        Invoke("ActivateCanvas", delayBeforeAppearance);
    }

    void ActivateCanvas()
    {
        // Activar el Canvas
        if (canvas != null) canvas.SetActive(true);

        // Iniciar la animación de la imagen
        if (imageAnimator != null)
        {
            imageAnimator.SetTrigger("StartAnimation");
        }
    }

    // Esta función será llamada por el evento de la animación
    public void OnAnimationEvent()
    {
        // Desactivar emptyObject1 y activar emptyObject2
        emptyObject1.SetActive(false);
        emptyObject2.SetActive(true);
    }
}
