using UnityEngine;

public class Nota : MonoBehaviour
{
    public bool canBePressed; // Indica si la flecha está en el área del botón
    public KeyCode keyToPress; // Tecla que debe ser presionada para esta flecha
    public int seccion; // Sección a la que pertenece la flecha (0 a 5)

    public RhythmGameController rhythmGameController; // Referencia al RhythmGameController
    private Collider2D activatorCollider; // Guarda el collider del botón activador cuando la flecha entra

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            if (activatorCollider != null)
            {
                // Obtener la posición de la flecha
                Vector3 flechaPos = transform.position;

                // Llamar al controlador de ritmo con la posición de la flecha
                rhythmGameController.RegisterHit(seccion, flechaPos.y);

                // Desactivar la flecha
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
            activatorCollider = other; // Guardar el activador en el que entró la flecha
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = false;
            activatorCollider = null; // Eliminar referencia al activador
        }
    }
}
