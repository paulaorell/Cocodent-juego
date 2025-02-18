using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script para las notas - Hit or Miss
public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;

    public static GameManager instance; // Singleton para acceder desde otros scripts

    public int scorePerNote = 100;
    public Slider dentalHealthSlider;

    void Start()
    {
        instance = this;
        
        // Inicia la música automáticamente para sincronizar con el movimiento de las notas
        theMusic.Play();
        startPlaying = true;
    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time");
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
