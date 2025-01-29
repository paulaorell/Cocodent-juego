using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script para las notas - Hit or Miss
public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;

    public static GameManager instance; //mismo valor para todos los scripts del gameManager para las hit notes. Todos los scripts tomaran elvalor modificado

    public int scorePerNote = 100;
    public Slider dentalHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

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
