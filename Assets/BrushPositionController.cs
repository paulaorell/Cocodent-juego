using UnityEngine;

public class BrushPositionController : MonoBehaviour
{
    public Animator animator; // Animator que controla la rotaci�n
    public Transform[] positions; // Las diferentes posiciones a las que se mover� el cepillo
    public float[] moveTimes; // Los tiempos despu�s de los cuales se mover� el cepillo
    private int currentPositionIndex = 0; // Indice de la posici�n actual
    private float elapsedTime = 0f; // Contador de tiempo

    void Update()
    {
        // Acumulamos el tiempo
        elapsedTime += Time.deltaTime;

        // Comprobamos si se ha alcanzado uno de los tiempos para mover el cepillo
        if (currentPositionIndex < moveTimes.Length && elapsedTime >= moveTimes[currentPositionIndex])
        {
            // Mover el cepillo a la nueva posici�n
            transform.position = positions[currentPositionIndex].position;

            // Activar la animaci�n de movimiento (si existe en el Animator)
            animator.SetTrigger("MoveBrush");

            // Avanzar a la siguiente posici�n
            currentPositionIndex++;
        }
    }
}
