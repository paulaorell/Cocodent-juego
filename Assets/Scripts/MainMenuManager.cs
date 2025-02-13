using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI xpText;  // Referencia al TextMeshPro para mostrar XP
    public TextMeshProUGUI coinsText;  // Referencia al TextMeshPro para mostrar monedas

    void Start()
    {
        // Verificar si los objetos de texto están asignados
        if (xpText != null)
        {
            // Mostrar el valor de playerXp desde GameDataManager
            xpText.text = GameDataManager.Instance.playerXp.ToString();
        }

        if (coinsText != null)
        {
            // Mostrar el valor de playerCoins desde GameDataManager
            coinsText.text = GameDataManager.Instance.playerCoins.ToString();
        }
    }
}
