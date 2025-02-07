using UnityEngine;
using UnityEngine.UI;

public class RhythmGameController : MonoBehaviour
{
    public GameObject[] mugreSections;
    public Slider scoreSlider;

    [Header("Parámetros de precisión")]
    public float perfectMin = -4.1f;
    public float perfectMax = -3.3f;
    public float goodMin = -3.29f;
    public float goodMax = -2.68f;
    public float normalMin = -2.68f;
    public float normalMax = -2.16f;

    public float perfectMultiplier = 1f;
    public float goodMultiplier = 0.75f;
    public float normalMultiplier = 0.5f;

    [Header("Configuración de secciones")]
    public int[] flechasPorSeccion;

    [Header("Configuración de Puntaje")]
    public int totalFlechas = 4;
    private float puntajePorFlecha;
    private float valorComida;

    private float[] opacidadMugre;
    private SpriteRenderer[] mugreRenderers;
    private float score = 0f;

    private GameMCandys gameMCandys;

    void Start()
    {
        gameMCandys = GameMCandys.Instance;

        opacidadMugre = new float[mugreSections.Length];
        mugreRenderers = new SpriteRenderer[mugreSections.Length];

        for (int i = 0; i < mugreSections.Length; i++)
        {
            mugreRenderers[i] = mugreSections[i].GetComponent<SpriteRenderer>();
            opacidadMugre[i] = 1f;
        }

        puntajePorFlecha = 100f / totalFlechas;
        valorComida = 2f / puntajePorFlecha;

        if (scoreSlider != null)
        {
            scoreSlider.minValue = 0;
            scoreSlider.maxValue = 100;
            scoreSlider.value = 0;
        }
    }

    public void RegisterHit(int seccion, float posicionFlecha)
    {
        float precision = CalculateHitPrecision(posicionFlecha);
        int totalFlechasSeccion = flechasPorSeccion[seccion];
        float reduccionBase = 1f / totalFlechasSeccion;
        float reduccionOpacidad = 0f;
        float puntajeSumar = 0f;
        string hitType = "Miss";

        if (precision == 1f)
        {
            reduccionOpacidad = reduccionBase * perfectMultiplier;
            puntajeSumar = puntajePorFlecha * 1f;
            hitType = "Perfect Hit!";
        }
        else if (precision == 0.75f)
        {
            reduccionOpacidad = reduccionBase * goodMultiplier;
            puntajeSumar = puntajePorFlecha * 0.75f;
            hitType = "Good Hit!";
        }
        else if (precision == 0.5f)
        {
            reduccionOpacidad = reduccionBase * normalMultiplier;
            puntajeSumar = puntajePorFlecha * 0.5f;
            hitType = "Normal Hit!";
        }

        opacidadMugre[seccion] -= reduccionOpacidad;
        opacidadMugre[seccion] = Mathf.Max(opacidadMugre[seccion], 0f);

        mugreRenderers[seccion].color = new Color(mugreRenderers[seccion].color.r, mugreRenderers[seccion].color.g, mugreRenderers[seccion].color.b, opacidadMugre[seccion]);

        score += puntajeSumar;

        if (scoreSlider != null)
        {
            scoreSlider.value = score;
        }

        Debug.Log($"{hitType} en la sección {seccion}! Reducción de opacidad: {reduccionOpacidad}, Nueva opacidad: {opacidadMugre[seccion]}, Puntaje ganado: {puntajeSumar}, Puntaje total: {score}");
    }

    public void CalcularPuntajeFinal()
    {
        if (gameMCandys != null)
        {
            Debug.Log("Entrando en calcularpuintajefinal");
            int comidas = gameMCandys.foodCount;
            int dulces = gameMCandys.candyCount;

            float puntajeComida = comidas * valorComida;
            float puntajeDulce = dulces * valorComida;

            Debug.Log($"PUNTAJE ANTES DEL AJUSTE: {score}");
            Debug.Log($"Comidas consumidas: {comidas}, Valor agregado: +{puntajeComida}");
            Debug.Log($"Dulces consumidos: {dulces}, Valor restado: -{puntajeDulce}");

            score += puntajeComida;
            score -= puntajeDulce;
            score = Mathf.Max(0, score);

            if (scoreSlider != null)
            {
                scoreSlider.value = score;
            }

            Debug.Log($"PUNTAJE FINAL AJUSTADO: {score}");
        }
        else
        {
            Debug.LogWarning("No se encontró GameMCandys.");
        }
    }

    private float CalculateHitPrecision(float posicionFlecha)
    {
        if (posicionFlecha >= perfectMin && posicionFlecha <= perfectMax)
        {
            return 1f;
        }
        else if (posicionFlecha >= goodMin && posicionFlecha <= goodMax)
        {
            return 0.75f;
        }
        else if (posicionFlecha >= normalMin && posicionFlecha <= normalMax)
        {
            return 0.5f;
        }
        return 0f;
    }
}
