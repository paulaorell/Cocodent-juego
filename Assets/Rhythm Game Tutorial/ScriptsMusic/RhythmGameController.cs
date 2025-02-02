using UnityEngine;
using UnityEngine.UI;

public class RhythmGameController : MonoBehaviour
{
    // Array para las secciones de mugre que se van a hacer invisibles.
    public Image[] mugreSections;

    // Umbrales de precisión editables desde el Inspector.
    [Header("Umbrales de precisión")]
    public float perfectThreshold = 0.93f; // Margen para un perfecto (más fácil para lograr un perfecto).
    public float goodThreshold = 0.95f;    // Margen para un buen acierto.
    public float acceptableThreshold = 0.98f; // Margen para un acierto aceptable.

    // Número de flechas por cada sección de mugre.
    public int[] flechasPorSeccion;

    // Opacidad de cada sección de mugre.
    private float[] opacidadMugre;

    void Start()
    {
        // Inicializamos la opacidad de las mugres al máximo (1)
        opacidadMugre = new float[mugreSections.Length];
        for (int i = 0; i < mugreSections.Length; i++)
        {
            opacidadMugre[i] = 1f; // 100% visible
        }
    }

    // Método para registrar un acierto.
    public void RegisterHit(int seccion, float timingDifference)
    {
        // Calcular el porcentaje de acierto según la diferencia de tiempo.
        float porcentajeAcierto = CalculateAccuracy(timingDifference);

        // Reducir la opacidad de la mugre según el porcentaje de acierto.
        float porcentajePorFlecha = 1f / Mathf.Max(flechasPorSeccion[seccion], 1); // Acierto por flecha.
        opacidadMugre[seccion] -= porcentajePorFlecha * porcentajeAcierto * 5f; // Aumento la reducción

        // Asegurarse de que la opacidad no sea menor que 0.
        opacidadMugre[seccion] = Mathf.Max(opacidadMugre[seccion], 0f);

        // Actualizar la visualización de la mugre.
        mugreSections[seccion].color = new Color(1f, 1f, 1f, opacidadMugre[seccion]);
    }

    // Método para calcular el porcentaje de acierto según la diferencia de tiempo.
    private float CalculateAccuracy(float timingDifference)
    {
        if (timingDifference <= perfectThreshold)
        {
            return 1f; // Perfecto (100%)
        }
        else if (timingDifference <= goodThreshold)
        {
            return 0.75f; // Bueno (75%)
        }
        else if (timingDifference <= acceptableThreshold)
        {
            return 0.5f; // Aceptable (50%)
        }
        else
        {
            return 0.25f; // Regular (25%)
        }
    }
}
