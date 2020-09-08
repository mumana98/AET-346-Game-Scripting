using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Text KeyObtainedText; //Instantiates a text named KeyObtainedText
    // Start is called before the first frame update
    void Start()
    {
        KeyObtainedText = GameObject.FindGameObjectWithTag("KeyText").GetComponent<Text>(); //sets KeyObtainedText to the object with the tag KeyText's text component
        KeyObtainedText.gameObject.SetActive(false); //sets inactive KeyObtainedText's game object
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Key") //checks if the object that this script is attached to has the tag Key
        {
            if (other.tag == "Player")//checks if others tag is Player
            {
                GameObject.FindGameObjectWithTag("Door").GetComponent<Door>().hasKey = true; // finds the object with the tag Door and goes into its Door script component function to set hasKey to true
                KeyObtainedText.gameObject.SetActive(true); // sets active the KeyObtainedText game object 
                Destroy(gameObject); //destroys the game object this script is attached to
            }
        }
    }
}
