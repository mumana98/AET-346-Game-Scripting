using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject[] savepoints; //Instantiates a GameObject array named savepoints
    public Vector3 CurrentSavePoint; //Instantiates a Vector3 named CurrentSavePoint
    public Vector3 StartPoint;//Instantiates a Vector3 named StartPoint

    // Start is called before the first frame update
    void Start()
    {
        savepoints = GameObject.FindGameObjectsWithTag("SavePoint"); //sets the array savepoints equal to all objects with the tag SavePoint
        StartPoint = GameObject.FindGameObjectWithTag("StartPoint").transform.position; //Sets StartPoint to the game object with the tag StartPoint position
        CurrentSavePoint = StartPoint; //sets CurrentSavePoint to StartPoint
    }

    // Update is called once per frame
    void Update()
    {

    }



}
