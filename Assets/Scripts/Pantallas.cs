using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pantallas : MonoBehaviour
{
    public GameDataManager gameDataManager;
        //public List<int> scoreF = new List<int>();


    // Start is called before the first frame update
    public void CambiarEscena(string nombre)
        {
            SceneManager.LoadScene(nombre);
        }


       // void Start ()
        //{
           // scoreF=gameDataManager.scoreF;

           // if(scoreF.Count>0)
           // {
           // foreach (var score in scoreF)
           // {
                //print(score);
            //}
            //}


        //}

}
