using UnityEngine;
using TMPro;

public class GanoUIManager_1 : MonoBehaviour
{
    public TextMeshProUGUI experienciaTexto;
    public TextMeshProUGUI monedasTexto;

    public GameObject diente1;
    public GameObject diente2;
    public GameObject diente3;

    void Start()
    {
        // Cargar datos ganados en este nivel
        int experienciaGanada = PlayerPrefs.GetInt("ExperienciaGanada", 0);
        int monedasGanadas = PlayerPrefs.GetInt("MonedasGanadas", 0);
        int scoreFinal = PlayerPrefs.GetInt("ScoreFinal", 0);

        // Mostrar en la UI
        experienciaTexto.text = "EXP Ganada: " + experienciaGanada;
        monedasTexto.text = "Monedas Ganadas: " + monedasGanadas;

        // Configurar los sprites de los dientes
        MostrarDientes(scoreFinal);
    }

    void MostrarDientes(int score)
    {
        diente1.SetActive(false);
        diente2.SetActive(false);
        diente3.SetActive(false);

        if (score >= 20 && score <= 40)
        {
            diente1.SetActive(true);
        }
        else if (score >= 41 && score <= 84)
        {
            diente1.SetActive(true);
            diente2.SetActive(true);
        }
        else if (score >= 85 && score <= 100)
        {
            diente1.SetActive(true);
            diente2.SetActive(true);
            diente3.SetActive(true);
        }
    }
}
