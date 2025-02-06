using UnityEngine;
using System.Collections;

public class Transicion : MonoBehaviour
{
    public Animator animator;
    public GameObject newObject;
    public float delay = 3f; // Tiempo antes de cambiar de objeto

    public void StartTransitionAtSpecificTime()
    {
        StartCoroutine(DelayedTransition());
    }

    private IEnumerator DelayedTransition()
    {
        yield return new WaitForSeconds(delay); // Espera el tiempo específico
        animator.SetTrigger("Desaparecer");
        yield return new WaitForSeconds(1f); // Tiempo para que termine la animación
        gameObject.SetActive(false);
        newObject.SetActive(true);
    }
}