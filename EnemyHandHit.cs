using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandHit : MonoBehaviour
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
            other.GetComponent<Player>().Health -= 10; //goes into others Player script to decease Health by 10
        }
    }
}
