using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool hasKey; //instantiates a boolean named hasKey
    // Start is called before the first frame update
    void Start()
    {
        hasKey = false; //sets hasKey to false
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //checks if others tag is Player
        {
            if (hasKey) //checks if hasKey is true
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().NextLevel(); //executes the NextLevel function in the object with the tag GameController located in the GameManager script which would be its component
            }
        }
    }
}
