using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //checks if others tag is Player
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Crystals += 1; //Finds the obbject with the GameController tag and goes into its GameManager script to increase Crystals by 1
            Destroy(gameObject); //destroys the game object this script is attached to
        }
    }

}
