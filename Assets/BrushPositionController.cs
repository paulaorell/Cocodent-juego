using UnityEngine;

public class BrushPositionController : MonoBehaviour
{
    public Animator animator; // Animator que controla la rotación
    public Transform[] positions; // Las diferentes posiciones a las que se moverá el cepillo
    public float[] moveTimes; // Los tiempos después de los cuales se moverá el cepillo
    private int currentPositionIndex = 0; // Indice de la posición actual
    private float elapsedTime = 0f; // Contador de tiempo

    void Update()
    {
        // Acumulamos el tiempo
        elapsedTime += Time.deltaTime;

        // Comprobamos si se ha alcanzado uno de los tiempos para mover el cepillo
        if (currentPositionIndex < moveTimes.Length && elapsedTime >= moveTimes[currentPositionIndex])
        {
            // Mover el cepillo a la nueva posición
            transform.position = positions[currentPositionIndex].position;

            // Activar la animación de movimiento (si existe en el Animator)
            animator.SetTrigger("MoveBrush");

            // Avanzar a la siguiente posición
            currentPositionIndex++;
        }
    }
}
