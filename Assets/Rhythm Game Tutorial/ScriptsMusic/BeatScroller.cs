using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo; // Qué tan rápido bajan las flechas según el tempo de la canción

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f; // Convierte el tempo a unidades por segundo
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve las flechas hacia abajo automáticamente
        transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
    }
}
