using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorAndKey : MonoBehaviour
{
    public Text KeyObtainedText;
    public bool hasKey;


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
        if (gameObject.tag == "Door")
        {
            if (other.tag == "Player" && hasKey)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().NextLevel();
            }
        }

        if (gameObject.tag == "Key")
        {
            if (other.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Door").GetComponent<DoorAndKey>().hasKey = true;
                GameObject.FindGameObjectWithTag("Key").GetComponent<DoorAndKey>().hasKey = true;
                KeyObtainedText.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
