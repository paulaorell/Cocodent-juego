using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pantallas : MonoBehaviour
{
    // Start is called before the first frame update
    public void CambiarEscena(string nombre)
        {
            SceneManager.LoadScene(nombre);
        }
}
