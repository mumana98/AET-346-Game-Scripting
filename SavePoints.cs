using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoints : MonoBehaviour
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
            GameObject.FindGameObjectWithTag("Save").GetComponent<Save>().CurrentSavePoint = gameObject.transform.position; //sets CurrentSavePoint located in the game object with the tag Save in its Save Script component to the game object this script is attached to 
            gameObject.SetActive(false); // sets inactive the game object this script is attached to
        }
    }
}
