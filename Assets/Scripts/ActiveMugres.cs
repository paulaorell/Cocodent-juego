using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMugres : MonoBehaviour

{
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    public GameObject Obj4;
    // Start is called before the first frame update
    public void Activar()
    {
        Obj1.SetActive (true);
        Obj2.SetActive (true);
        Obj3.SetActive (true);
        Obj4.SetActive (true);
    }
}
