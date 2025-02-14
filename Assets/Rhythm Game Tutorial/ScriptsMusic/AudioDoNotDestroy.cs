using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
        if(musicObj.Length > 1)
    {
        Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
    }
}
