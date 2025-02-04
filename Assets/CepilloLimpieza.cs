using UnityEngine;
using System.Collections;

public class CepilloLimpieza : MonoBehaviour
{
    public Transform[] posicionesSecciones; // Puntos donde cepillar�
    public ParticleSystem burbujas; // Part�culas de burbujas del cepillo
    public float tiempoPorSeccion = 1.5f; // Tiempo en cada secci�n
    public float velocidadMovimiento = 5f; // Velocidad de transici�n entre secciones

    private int indiceActual = 0; // �ndice de la secci�n actual
    private bool enMovimiento = false; // Control para evitar m�ltiples movimientos

    private void Start()
    {
        if (posicionesSecciones.Length > 0)
        {
            transform.position = posicionesSecciones[0].position; // Iniciar en la primera secci�n
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

            // Detener burbujas al finalizar la secci�n
            burbujas.Stop();

            // Pasar a la siguiente secci�n
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
