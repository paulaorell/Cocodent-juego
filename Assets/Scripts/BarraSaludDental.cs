using UnityEngine;
using UnityEngine.UI;

public class BarraSaludDental : MonoBehaviour
{
    public Slider dentalHealthSlider; // Referencia al Slider (barra de salud dental)
    public int maxFoodCount = 10;    // Máximo número de alimentos antes de vaciar la barra

    private int foodCount = 0;       // Contador de alimentos consumidos

    void Start()
    {
        // Inicializa el slider en la mitad
        if (dentalHealthSlider != null)
        {
            dentalHealthSlider.value = 0.5f; // El handle comienza en la mitad
        }
    }

    // Método público para incrementar el contador de alimentos
    public void IncrementFoodCount()
    {
        foodCount++;

        // Calcula el nuevo valor del slider
        if (dentalHealthSlider != null)
        {
            float newValue = Mathf.Clamp01(0.5f - ((float)foodCount / maxFoodCount) * 0.5f); // Reduce proporcionalmente
            dentalHealthSlider.value = newValue;
        }

        // Comprobar si la barra está vacía
        if (foodCount >= maxFoodCount)
        {
            Debug.Log("¡Salud dental vacía!");
            // Aquí puedes realizar acciones, como mostrar un mensaje o finalizar el juego.
        }
    }
}
