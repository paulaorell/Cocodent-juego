using System.Collections.Generic;
using UnityEngine;

public class ControladorBoton : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    public RhythmGameController rhythmGameController; // Referencia al RhythmGameController

    private List<GameObject> flechasEnZona = new List<GameObject>(); // Lista de flechas en la zona del botón

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) // Cambia la imagen cuando la tecla se aplasta
        {
            theSR.sprite = pressedImage;

            // Verificar si hay flechas en la zona
            if (flechasEnZona.Count > 0)
            {
                // Tomar la primera flecha de la lista
                GameObject flecha = flechasEnZona[0];

                // Obtener el script de la flecha para calcular la diferencia de posición
                Nota flechaScript = flecha.GetComponent<Nota>();

                if (flechaScript != null)
                {
                    int seccion = flechaScript.seccion;
                    Vector3 flechaPos = flecha.transform.position; // Posición de la flecha
                    Vector3 pressPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Posición de la tecla presionada

                    // Eliminar la componente Z para trabajar solo en 2D
                    flechaPos.z = 0;
                    pressPos.z = 0;

                    // Calcular la distancia entre la flecha y la posición de la tecla presionada
                    float distancia = Vector3.Distance(flechaPos, pressPos);

                    // Llamar al RhythmGameController con la distancia
                    rhythmGameController.RegisterHit(seccion, distancia);

                    // Eliminar la flecha de la lista y destruirla
                    flechasEnZona.RemoveAt(0);
                    Destroy(flecha);
                }
            }
        }

        if (Input.GetKeyUp(keyToPress)) // Cambia la imagen cuando la tecla se suelta
        {
            theSR.sprite = defaultImage;
        }
    }

    // Detectar cuando una flecha entra en la zona del botón
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flecha")) // Asegúrate de que las flechas tengan el tag "Flecha"
        {
            flechasEnZona.Add(other.gameObject);
        }
    }

    // Detectar cuando una flecha sale de la zona del botón
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Flecha"))
        {
            flechasEnZona.Remove(other.gameObject);
        }
    }
}
