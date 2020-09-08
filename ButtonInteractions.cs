using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().LoadSave();  //finds the game object with the tag GameController and gets its GameManager script and executes the LoadSave function
    }

    public void StartNewGame()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().StartNew(); //finds the game object with the tag GameController and gets its GameManager script and executes the StartNew function
    }
}
