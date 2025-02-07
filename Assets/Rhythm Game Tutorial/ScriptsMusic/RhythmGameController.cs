using UnityEngine;
using UnityEngine.UI;

public class RhythmGameController : MonoBehaviour
{
    public GameObject[] mugreSections;
    public Slider scoreSlider;

    [Header("Par�metros de precisi�n")]
    public float perfectMin = -4.1f;
    public float perfectMax = -3.3f;
    public float goodMin = -3.29f;
    public float goodMax = -2.68f;
    public float normalMin = -2.68f;
    public float normalMax = -2.16f;

    public float perfectMultiplier = 1f;
    public float goodMultiplier = 0.75f;
    public float normalMultiplier = 0.5f;

    [Header("Configuraci�n de secciones")]
    public int[] flechasPorSeccion;

    [Header("Configuraci�n de Puntaje")]
    public int totalFlechas = 4; // Puedes cambiar esto en el editor
    private float puntajePorFlecha;

    private float[] opacidadMugre;
    private SpriteRenderer[] mugreRenderers;
    private float score = 0f;

    void Start()
    {
        opacidadMugre = new float[mugreSections.Length];
        mugreRenderers = new SpriteRenderer[mugreSections.Length];

        for (int i = 0; i < mugreSections.Length; i++)
        {
            mugreRenderers[i] = mugreSections[i].GetComponent<SpriteRenderer>();
            opacidadMugre[i] = 1f;
        }

        // Calculamos cu�nto vale cada flecha en la barra de puntaje
        puntajePorFlecha = 100f / totalFlechas;

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

        Debug.Log($"{hitType} en la secci�n {seccion}! Reducci�n de opacidad: {reduccionOpacidad}, Nueva opacidad: {opacidadMugre[seccion]}, Puntaje ganado: {puntajeSumar}, Puntaje total: {score}");
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
