using UnityEngine;
using TMPro;

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
