using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyOnLoad : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(gameObject); //does not destroy the gameObject upon loading the next scene
    }

    void Update()
    {
        
    }
}
