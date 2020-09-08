using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using GameObject = UnityEngine.GameObject;

public class Enemy : MonoBehaviour
{

    public float EnemyHealth; //Instantiates a float named EnemyHealth
    public GameObject[] waypoints; //Instantiates a gameobject array named waypoints
    private int CurrentWaypoint; //instantiates a private int named CurrentWayPoint
    public Slider EnemyHealthBar; // instantiates a slider named EnemyHealthBar
    private NavMeshAgent MyAgent; //instantiates a navmeshagent named MyAgent
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = 100; //sets EnemyHealth to 100
        waypoints = GameObject.FindGameObjectsWithTag("EnemyWayPoint"); // sets waypoint equal to all objects with the tag "EnemyWayPoint"
        MyAgent = GetComponent<NavMeshAgent>(); //sets MyAgent equal to this objects NavMeshAgent
        MyAgent.destination = waypoints[CurrentWaypoint].transform.position; //sets MyAgents destination equal to the waypoint in the CurrentWayPoint position

    }

    // Update is called once per frame
    void Update()
    {

        EnemyHealthBar.value = EnemyHealth; //sets equal the value of the slider to the enemies health (EnemyHealth)
        EnemyHealthBar.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform); //the EnemyHealthBar looks at the game object with the tag Player

        if (EnemyHealth <= 0) //checks if EnemyHealth is less than or equal to 0
        {
            MyAgent.destination = transform.position; // sets MyAgents destination to this objects position (or stops it from moving)
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Die"); //gets the child animator component and triggers Die
            Destroy(gameObject, 3); //destroys the game object this script is attached to after 3 seconds
            
            //gameObject.SetActive(false);
        }

        if (EnemyHealth > 0) // checks if EnemyHealth is greater than 0
        {
            if (Vector3.Distance(MyAgent.destination, transform.position) <= 2) //checks if the distance from the destination and itself is less than or equal to 2
            {
                CurrentWaypoint++; //adds 1 to currentwaypoint

            }

            if ((Vector3.Distance(MyAgent.destination, transform.position) >= 2) &&
                (Vector3.Distance(MyAgent.transform.position,
                     GameObject.FindGameObjectWithTag("Player").transform.position) >=
                 7)) //checks if distance from MyAgents destination to its position is greater than or equal to 2 and its position to the players position is greater than or equal to 7
            {
                if (CurrentWaypoint >= waypoints.Length
                ) //checks if currentwaypoint is greater than or equal to waypoints array length
                {
                    CurrentWaypoint = 0; //sets currentwaypoint to 0
                }

                MyAgent.destination =
                    waypoints[CurrentWaypoint].transform
                        .position; //sets MyAgents destination equal to the waypoint in the CurrentWayPoint position
            }

            else
            {
                MyAgent.destination = GameObject.FindGameObjectWithTag("Player").transform.position; //sets MyAgents destination to the object with the Player tags position

                if (Vector3.Distance(MyAgent.transform.position,
                        GameObject.FindGameObjectWithTag("Player").transform.position) <= 2)// checks if MyAgents distance from the object with the Player tags position is less than 2
                {
                    gameObject.GetComponentInChildren<Animator>().SetTrigger("Close"); //gets the child animator component and triggers Close
                }
                else
                {
                    gameObject.GetComponentInChildren<Animator>().SetTrigger("NotClose");//gets the child animator component and triggers NotClose
                }
            }
        }
    }


}
