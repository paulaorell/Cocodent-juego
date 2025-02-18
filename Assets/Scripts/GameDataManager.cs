using UnityEngine;
using System.Collections.Generic;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    // Variables para almacenar los valores
    public int lastScore;
    public int playerXp;
    public int playerCoins;
    //public List<int> scoreF = new List<int>();


    // Método Awake() para asegurarse de que solo haya una instancia de GameDataManager
    void Awake()
    {
        // Verifica si ya existe una instancia del GameDataManager
        if (Instance == null)
        {
            Instance = this;  // Asigna esta instancia a la variable estática
            DontDestroyOnLoad(gameObject);  // No destruir este objeto cuando se cambie de escena
        }
        else
        {
            Destroy(gameObject);  // Si ya existe, destruye el nuevo GameDataManager
        }
    }

    // Método para actualizar el puntaje (llamado al final del juego, cuando se obtiene un nuevo puntaje)
    public void UpdateScore(int score)
    {
        //scoreF.Add(score);
        lastScore = score;  // Guarda el puntaje del juego actual
        PlayerPrefs.SetInt("LastScore", lastScore);  // Guardar el puntaje para que persista entre sesiones
        
    }

    // Método para agregar experiencia y monedas
    public void AddRewards(int xp, int coins)
    {
        playerXp += xp;  // Suma la experiencia ganada
        playerCoins += coins;  // Suma las monedas ganadas

        // Guardar valores de XP y monedas de manera persistente
        PlayerPrefs.SetInt("PlayerXp", playerXp);
        PlayerPrefs.SetInt("PlayerCoins", playerCoins);
    }

    // Método para resetear los datos (si en algún momento se necesita reiniciar)
    public void ResetData()
    {
        lastScore = 0;
        playerXp = 0;
        playerCoins = 0;

        // Resetear valores persistentes
        PlayerPrefs.DeleteKey("LastScore");
        PlayerPrefs.DeleteKey("PlayerXp");
        PlayerPrefs.DeleteKey("PlayerCoins");
    }

    // Métodos para obtener los valores actuales de experiencia y monedas
    public int GetPlayerXp()
    {
        return playerXp;
    }

    public int GetPlayerCoins()
    {
        return playerCoins;
    }
}
