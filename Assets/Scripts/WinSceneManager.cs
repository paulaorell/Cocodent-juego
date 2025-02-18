using UnityEngine;
using TMPro;

public class WinSceneManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI coinsText;
    public GameObject sprite1, sprite2, sprite3;

    void Start()
    {
        // Verificar si GameDataManager est� correctamente inicializado
        if (GameDataManager.Instance == null)
        {
            Debug.LogError("GameDataManager no est� inicializado.");
            return; // Salir del m�todo si no est� inicializado
        }
 }
        void Update()
    {
        // Obtener el puntaje desde GameDataManager
        int score = GameDataManager.Instance.lastScore;  // Aqu� estamos obteniendo el puntaje que ya ha sido calculado
        int xp = 0;
        int coins = 0;

        // L�gica de distribuci�n de XP y monedas seg�n el puntaje
        if (score >= 20 && score <= 40)
        {
            sprite1.SetActive(true);
            xp = 200;
            coins = 25;
        }
        else if (score >= 41 && score <= 84)
        {
            sprite2.SetActive(true);
            xp = 300;
            coins = 50;
        }
        else if (score >= 85 && score <= 100)
        {
            sprite3.SetActive(true);
            xp = 400;
            coins = 100;
        }
        Debug.LogError("do ."+score );
   
        // Mostrar los valores en pantalla
        //scoreText.text = "Puntuaci�n: " + score;
        //xpText.text = "Experiencia: " + xp;
        //coinsText.text = "Monedas: " + coins;

        // Guardar las recompensas en GameDataManager
        //GameDataManager.Instance.AddRewards(xp, coins);

        // Mostrar los valores en pantalla
        if (scoreText != null) scoreText.text = "Puntuaci�n: " + score;
        if (xpText != null) xpText.text = xp.ToString();
        if (coinsText != null) coinsText.text = coins.ToString();

        // Guardar las recompensas en GameDataManager
        GameDataManager.Instance.AddRewards(xp, coins);
    }
} 
