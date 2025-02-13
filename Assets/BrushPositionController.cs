using System.Collections;
using UnityEngine;

public class BrushController : MonoBehaviour
{
    public Animator animator;  // El Animator del cepillo
    public Transform[] positions;  // Posiciones a las que se moverá
    public float[] moveTimes;  // Tiempos de espera antes de moverse
    public float moveSpeed = 2f; // Velocidad de movimiento

    private int index = 0; // Índice de posición

    void Start()
    {
        StartCoroutine(MoveBrush());
    }

    IEnumerator MoveBrush()
    {
        while (true)
        {
            
            
            animator.SetTrigger("MoveToPosition"); // Activa la animación de rotación
            
            Vector3 startPos = transform.position;
            Vector3 targetPos = positions[index].position;
            float t = 0;

            while (t < 1)
            {
                t += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(startPos, targetPos, t);
                yield return null;
            }

            index = (index + 1) % positions.Length; // Pasa a la siguiente posición
            yield return new WaitForSeconds(moveTimes[index]); // Espera el tiempo definido
        }
    }
}
