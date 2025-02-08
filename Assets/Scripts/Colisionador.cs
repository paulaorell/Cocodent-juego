using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisionador : MonoBehaviour
{
    public RhythmGameController rhythmGameController; // Ahora está dentro de la clase
    private int ColisionFlecha; // Entero para contar las colisiones

    void Start()
    {
        ColisionFlecha = 0; 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flecha"))
        {
            ColisionFlecha++; // Ahora sí usa la lista correctamente
            
            if (rhythmGameController != null) 
            {
               // rhythmGameController.numFlechas = ColisionFlecha; // Asegúrate de que esta variable exista en RhythmGameController
            }

        }
    }
}
