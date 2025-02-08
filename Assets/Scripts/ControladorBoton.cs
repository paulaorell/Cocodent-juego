using System.Collections.Generic;
using UnityEngine;

public class ControladorBoton : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;
    public RhythmGameController rhythmGameController; // Referencia al RhythmGameController

    private List<GameObject> flechasEnZona = new List<GameObject>(); // Lista de flechas en la zona del bot�n

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) // Cambia la imagen cuando la tecla se presiona
        {
            theSR.sprite = pressedImage;

            // Verificar si hay flechas en la zona
            if (flechasEnZona.Count > 0)
            {
                // Tomar la primera flecha de la lista
                GameObject flecha = flechasEnZona[0];

                // Obtener el script de la flecha
                Nota flechaScript = flecha.GetComponent<Nota>();

                if (flechaScript != null)
                {
                    int seccion = flechaScript.seccion;
                    Transform flechaTransform = flecha.transform; // Usamos el transform completo de la flecha

                    // Llamar a RhythmGameController con la secci�n y la posici�n de la flecha
                    rhythmGameController.RegisterHit(seccion, flechaTransform.position.y);

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

    // Detectar cuando una flecha entra en la zona del bot�n
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flecha")) // Aseg�rate de que las flechas tengan el tag "Flecha"
        {
            flechasEnZona.Add(other.gameObject);
        }
    }

    // Detectar cuando una flecha sale de la zona del bot�n
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Flecha"))
        {
            flechasEnZona.Remove(other.gameObject);
        }
    }
}
