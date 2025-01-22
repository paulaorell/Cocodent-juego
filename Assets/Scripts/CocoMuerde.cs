using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoMuerde : MonoBehaviour
{
    public float moveSpeed = 5f;          // Velocidad de movimiento del cocodrilo
    private float minY, maxY;            // Límites de la pantalla
    private Animator animator;           // Referencia al Animator

    public BarraSaludDental healthManager; // Referencia al script DentalHealthManager

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtiene el Animator del cocodrilo

        // Obtener los límites de la pantalla
        Camera cam = Camera.main;
        float screenHeight = cam.orthographicSize;
        minY = -screenHeight + 1f; // Ajusta según el tamaño del sprite
        maxY = screenHeight - 1f;  // Ajusta según el tamaño del sprite
    }

    void Update()
    {
        // Movimiento con teclas de flecha ARRIBA (↑) y ABAJO (↓)
        float verticalMovement = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) // Flecha arriba
        {
            verticalMovement = moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // Flecha abajo
        {
            verticalMovement = -moveSpeed * Time.deltaTime;
        }

        // Aplicar movimiento con límites
        float newY = Mathf.Clamp(transform.position.y + verticalMovement, minY, maxY);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food")) // Si choca con la comida
        {
            animator.SetTrigger("Eat"); // Activa la animación de comer
            Destroy(other.gameObject); // Destruye la comida

            // Incrementa el contador de alimentos en el DentalHealthManager
            if (healthManager != null)
            {
                healthManager.IncrementFoodCount();
            }
        }
    }
}
