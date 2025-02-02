using UnityEngine;

public class Nota : MonoBehaviour
{
    public bool canBePressed; // Indica si la flecha est� en el �rea del bot�n
    public KeyCode keyToPress; // Tecla que debe ser presionada para esta flecha
    public int seccion; // Secci�n a la que pertenece la flecha (0 a 5)

    public RhythmGameController rhythmGameController; // Referencia al RhythmGameController

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                // Calcular la diferencia de posici�n entre la flecha y el lugar donde se presion� la tecla
                Vector3 flechaPos = transform.position; // Posici�n de la flecha
                Vector3 pressPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Posici�n de la tecla presionada (convertida de pantalla a mundo)

                // Eliminar la componente Z para trabajar solo en 2D
                flechaPos.z = 0;
                pressPos.z = 0;

                // Calcular la distancia entre la flecha y la posici�n de la tecla presionada
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
        // Verificar si la flecha entra en el �rea del bot�n
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verificar si la flecha sale del �rea del bot�n
        if (other.CompareTag("Activator"))
        {
            canBePressed = false;
        }
    }
}
