using UnityEngine;

public class Nota : MonoBehaviour
{
    public bool canBePressed; // Indica si la flecha está en el área del botón
    public KeyCode keyToPress; // Tecla que debe ser presionada para esta flecha
    public int seccion; // Sección a la que pertenece la flecha (0 a 5)

    public RhythmGameController rhythmGameController; // Referencia al RhythmGameController

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                // Calcular la diferencia de posición entre la flecha y el lugar donde se presionó la tecla
                Vector3 flechaPos = transform.position; // Posición de la flecha
                Vector3 pressPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Posición de la tecla presionada (convertida de pantalla a mundo)

                // Eliminar la componente Z para trabajar solo en 2D
                flechaPos.z = 0;
                pressPos.z = 0;

                // Calcular la distancia entre la flecha y la posición de la tecla presionada
                float distancia = Vector3.Distance(flechaPos, pressPos);

                // Llamar al controlador de ritmo para registrar el acierto basado en la distancia
                rhythmGameController.RegisterHit(seccion, distancia);

                // Desactivar la flecha
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la flecha entra en el área del botón
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verificar si la flecha sale del área del botón
        if (other.CompareTag("Activator"))
        {
            canBePressed = false;
        }
    }
}
