using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coco : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del cocodrilo
    private float verticalMovement; // Almacenar� el movimiento vertical

    void Update()
    {
        // Movimiento hacia arriba y abajo
        verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Aplicar el movimiento
        transform.position += new Vector3(0, verticalMovement, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food")) // Aseg�rate de que los alimentos tengan el tag "Food"
        {
            Destroy(other.gameObject); // Destruye el alimento
        }
    }
}