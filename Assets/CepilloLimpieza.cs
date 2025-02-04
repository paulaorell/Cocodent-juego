using UnityEngine;
using System.Collections;

public class CepilloLimpieza : MonoBehaviour
{
    public Transform[] posicionesSecciones; // Puntos donde cepillará
    public ParticleSystem burbujas; // Partículas de burbujas del cepillo
    public float tiempoPorSeccion = 1.5f; // Tiempo en cada sección
    public float velocidadMovimiento = 5f; // Velocidad de transición entre secciones

    private int indiceActual = 0; // Índice de la sección actual
    private bool enMovimiento = false; // Control para evitar múltiples movimientos

    private void Start()
    {
        if (posicionesSecciones.Length > 0)
        {
            transform.position = posicionesSecciones[0].position; // Iniciar en la primera sección
            StartCoroutine(LimpiarSecciones());
        }
    }

    private IEnumerator LimpiarSecciones()
    {
        while (indiceActual < posicionesSecciones.Length)
        {
            yield return StartCoroutine(MoverACepillar(posicionesSecciones[indiceActual].position));

            // Activar burbujas mientras cepilla
            burbujas.Play();

            yield return new WaitForSeconds(tiempoPorSeccion);

            // Detener burbujas al finalizar la sección
            burbujas.Stop();

            // Pasar a la siguiente sección
            indiceActual++;
        }
    }

    private IEnumerator MoverACepillar(Vector3 destino)
    {
        enMovimiento = true;
        while (Vector3.Distance(transform.position, destino) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidadMovimiento * Time.deltaTime);
            yield return null;
        }
        enMovimiento = false;
    }
}
