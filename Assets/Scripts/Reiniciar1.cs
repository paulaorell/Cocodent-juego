using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar1 : MonoBehaviour
{
    public GameObject ReiniciarPanel;
    public AudioSource backgroundAudio;
    public string reiniciarNivel; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReloadLevel()
    {
        Time.timeScale = 1f; // Restablece el tiempo antes de cambiar de nivel.
        
        if (backgroundAudio != null)
        {
            backgroundAudio.Stop(); // Detiene la música antes de cambiar de escena.
            backgroundAudio.Play(); // Reproduce el audio desde el principio.
        }

        SceneManager.LoadScene(reiniciarNivel); // Carga el nivel especificado en el Inspector.
        ReiniciarPanel.SetActive(false);
    } 
}
