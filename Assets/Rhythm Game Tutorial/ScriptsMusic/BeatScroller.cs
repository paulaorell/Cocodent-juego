using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo; //que tan rapido van a bajar los circulos segun el tempo de la cancion
    
    public bool hasStarted;
    
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f; //divide el tempo en segundos para ver cuantos cuadritos se mueven los circulos
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKeyDown){
                hasStarted = true;
            }
        } else
        //los circulos van a bajar 2 cuadritos por segundo
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime,0f);
        }
    }
}
