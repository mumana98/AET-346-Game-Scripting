using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    public bool ItemCollected; //Instantiates a bool called ItemCollected
    public QuestGiver questGiver; //Instantiates an enemy named questGiver


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
        if (other.tag == "Player" && questGiver.questActive) //checks if others tag is equal to Player and if questActive is true for the questGiver object
        {
            ItemCollected = true; //sets ItemCollected to true
        }
    }
}
