using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RhythmGameController : MonoBehaviour
{
    public GameObject[] mugreSections;
    public Slider scoreSlider;
    public GameObject[] dientesSprites; // Los sprites de los dientes en la escena de "Gano"
    public TextMeshProUGUI experienciaTexto;
    public TextMeshProUGUI monedasTexto;

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
    private int flechasRegistradas = 0; // Contador de flechas registradas

    private GameMCandys gameMCandys;

    void Start()
    {
        gameMCandys = GameMCandys.Instance;

        if (gameMCandys == null)
        {
            Debug.LogError("GameMCandys.Instance no está inicializado.");
        }

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
        flechasRegistradas++;
        float precision = CalculateHitPrecision(posicionFlecha);
        float puntajeSumar = puntajePorFlecha * precision;

        score += puntajeSumar;
        scoreSlider.value = score;

        Debug.Log($"Puntaje total: {score}");

        if (flechasRegistradas >= totalFlechas)
        {
            CalcularPuntajeFinal();
        }
    }

    public void CalcularPuntajeFinal()
    {
        Debug.Log("Calculando puntaje final...");
        int comidas = gameMCandys.foodCount;
        int dulces = gameMCandys.candyCount;

        score += comidas * valorComida;
        score -= dulces * valorComida;
        score = Mathf.Max(0, score);

        scoreSlider.value = score;
        Debug.Log($"PUNTAJE FINAL AJUSTADO: {score}");

        DeterminarResultados();
    }

    private void DeterminarResultados()
    {
        int experienciaGanada = 0;
        int monedasGanadas = 0;

        if (score >= 20 && score <= 40)
        {
            experienciaGanada = 200;
            monedasGanadas = 25;
            dientesSprites[0].SetActive(true);
        }
        else if (score >= 41 && score <= 84)
        {
            experienciaGanada = 300;
            monedasGanadas = 50;
            dientesSprites[0].SetActive(true);
            dientesSprites[1].SetActive(true);
        }
        else if (score >= 85 && score <= 100)
        {
            experienciaGanada = 400;
            monedasGanadas = 100;
            dientesSprites[0].SetActive(true);
            dientesSprites[1].SetActive(true);
            dientesSprites[2].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Perdio");
            return;
        }

        ExpGameManager.Instance.AgregarRecompensas(experienciaGanada, monedasGanadas);

        experienciaTexto.text = $"Experiencia: {experienciaGanada}";
        monedasTexto.text = $"Monedas: {monedasGanadas}";

        SceneManager.LoadScene("Gano");
    }

    private float CalculateHitPrecision(float posicionFlecha)
    {
        if (posicionFlecha >= perfectMin && posicionFlecha <= perfectMax)
            return 1f;
        if (posicionFlecha >= goodMin && posicionFlecha <= goodMax)
            return 0.75f;
        if (posicionFlecha >= normalMin && posicionFlecha <= normalMax)
            return 0.5f;
        return 0f;
    }
}
