
using UnityEngine;
using UnityEngine.UI;

public class BarraSaludDental : MonoBehaviour
{
    public Slider dentalHealthSlider; // Referencia al Slider (barra de salud dental)
    public int maxCandyCount = 10; // Número máximo de golosinas antes de vaciar la barra

    private int candyCount = 0; // Contador de golosinas consumidas

    void Start()
    {
        // Inicializa el slider en la mitad
        if (dentalHealthSlider != null) //si la variable no tiene un valor asignado entonces...
        {
            dentalHealthSlider.value = 0.5f; // ...El handle comienza en la mitad
        }
    }

    // Método público para procesar comida
    public void ProcessFood(string foodType)
    {
        if (foodType == "Candy") // Si es una golosina, disminuye la barra
        {
            candyCount++;

            if (dentalHealthSlider != null)
            {
                float newValue = Mathf.Clamp01(0.5f - ((float)candyCount / maxCandyCount) * 0.5f);
                dentalHealthSlider.value = newValue;
            }

            if (candyCount >= maxCandyCount)
            {
                Debug.Log("¡Salud dental vacía!");
            }
        }
        else if (foodType == "Healthy") // Si es comida saludable, la barra se mantiene
        {
            Debug.Log("Comida saludable, la barra no cambia.");
        }
    }
}