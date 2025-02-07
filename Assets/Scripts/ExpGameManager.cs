using UnityEngine;
using TMPro;

public class ExpGameManager : MonoBehaviour
{
    public static ExpGameManager Instance;

    public int experienciaTotal = 0;
    public int monedasTotal = 0;
    public TextMeshProUGUI experienciaMenu;
    public TextMeshProUGUI monedasMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarRecompensas(int experiencia, int monedas)
    {
        experienciaTotal += experiencia;
        monedasTotal += monedas;
        ActualizarUI();
    }

    public void ActualizarUI()
    {
        if (experienciaMenu != null) experienciaMenu.text = $"Exp: {experienciaTotal}";
        if (monedasMenu != null) monedasMenu.text = $"Monedas: {monedasTotal}";
    }
}
