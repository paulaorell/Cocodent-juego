using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;
     
        // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(keyToPress)) //cambia la imagen cuando la tecla se aplasta
        {
            theSR.sprite = pressedImage;
        }
        if(Input.GetKeyUp(keyToPress)) //cambia la imagen cuando la tecla se suelta 
        {
            theSR.sprite = defaultImage;
        }

   }
    
}
