using UnityEngine;

public class Transicion : MonoBehaviour
{
    public GameObject emptyObject1; // Objeto que aparecerá después de 40 segundos
    public GameObject emptyObject2; // Objeto que aparecerá cuando se active el evento de la animación
    public float delayBeforeAppearance = 40f; // Tiempo en segundos antes de que aparezca el primer objeto

    private Animator imageAnimator; // Animator de la imagen

    void Start()
    {
        // Desactivar ambos objetos al inicio
        emptyObject1.SetActive(false);
        emptyObject2.SetActive(false);

        // Obtener el componente Animator del objeto con la imagen
        imageAnimator = GetComponent<Animator>();

        // Llamar a la función para activar el primer objeto después del tiempo especificado
        Invoke("ActivateFirstObject", delayBeforeAppearance);
    }

    void ActivateFirstObject()
    {
        // Activar el primer objeto
        emptyObject1.SetActive(true);

        // Iniciar la animación de la imagen
        if (imageAnimator != null)
        {
            imageAnimator.SetTrigger("StartAnimation");
        }
    }

    // Esta función será llamada por el evento de la animación
    public void OnAnimationEvent()
    {
        // Activar el segundo objeto
        emptyObject2.SetActive(true);
    }
}