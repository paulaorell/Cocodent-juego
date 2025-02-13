using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMCandys : MonoBehaviour
{
    public static GameMCandys Instance;

    public int foodCount = 0;
    public int candyCount = 0;

    public TMP_Text foodCounterText;
    public TMP_Text candyCounterText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el GameManager al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados
        }

        // Suscribirse al evento de carga de escenas
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    // Se llama cada vez que una nueva escena se carga
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si la escena cargada es la de "Prue part1_2", reiniciamos los contadores
        if (scene.name == "Prue part1_2")
        {
            foodCount = 0;
            candyCount = 0;
            UpdateFoodCounterText();
            UpdateCandyCounterText();
            
        }
       
    }

    private void OnDestroy()
    {
        // Desuscribirse del evento para evitar problemas al destruir el objeto
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void AddFood()
    {
        foodCount++;
        UpdateFoodCounterText();
    }

    public void AddCandy()
    {
        candyCount++;
        UpdateCandyCounterText();
    }

    public void UpdateFoodCounterText()
    {
        if (foodCounterText != null)
        {
            foodCounterText.text = "Food: " + foodCount;
        }
    }

    public void UpdateCandyCounterText()
    {
        if (candyCounterText != null)
        {
            candyCounterText.text = "Candy: " + candyCount;
        }
    }
}
