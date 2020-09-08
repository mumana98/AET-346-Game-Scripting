using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestGiver : MonoBehaviour
{
    public GameObject[] waypoints; //Instantiates a gameobject array named waypoints
    private NavMeshAgent MyAgent; //instantiates a navmeshagent named MyAgent
    private int CurrentWaypoint; //instantiates a private int named CurrentWayPoint
    private bool talking; //Instantiates a private bool named talking
    public GameObject QuestText; //instantiates a GameObject named QuestText
    private bool questItemFound; //Instantiates a private bool named questItemFound
    public QuestItem questItem; //Instantiates a QuestItem named questItem
    public bool questActive; //Instantiates a bool named questActive
    public Animator PopUpText; //Insantiates an animator named PopUpText
    public int questDone = 0; //Instantiates an int named questDone and sets it equal to 0
    public Scene currentScene; //Instantiates a Scene named currentScene
    private String sceneName; //Instantiates a private String named sceneName

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene(); //sets currentScene to active scene
        sceneName = currentScene.name;//sets sceneName equal to currentScenes name
        MyAgent = GetComponent<NavMeshAgent>(); //sets MyAgent equal to this objects NavMeshAgent
        MyAgent.destination = waypoints[CurrentWaypoint].transform.position; //sets MyAgents destination equal to the waypoint in the CurrentWayPoint position

    }

    // Update is called once per frame
    void Update()
    {
        if (!questItemFound && questItem.ItemCollected) //checks if not questItemFound and if ItemCollected is true
        {
            questItemFound = true; //sets questItemFound to true
            Destroy(questItem.gameObject); //destroys the questItem gameObject
            questDone = 2; //sets questDone to 2
        }
        if (Vector3.Distance(MyAgent.destination, transform.position) <= 4 && !talking) //checks if distance from MyAgents destination to its position is less than 4 and is not talking
        {
            CurrentWaypoint++; //adds 1 to currentwaypoint
            if (CurrentWaypoint >= waypoints.Length) //checks if currentwaypoint is greater than or equal to waypoints array length
            {
                CurrentWaypoint = 0; //sets currentwaypoint to 0
            }
            MyAgent.destination = waypoints[CurrentWaypoint].transform.position;  //sets MyAgents destination equal to the waypoint in the CurrentWayPoint position
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") //checks if others tag is Player
        {
            MyAgent.destination = transform.position; //sets destination to its immediate position
            if (!talking) //checks if not talking
            {
                if (questItemFound) //checks if questItemfound is true
                {

                    if (questDone == 2) //checks if questDone is 2
                    {
                        PopUpText.SetTrigger("PopUp"); //triggers PopUp for the PopUpText
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Crystals += 10; //increases Crystals in the GameManager script by 10
                        questItemFound = false;
                    }

                    if (questDone == 2) //checks if questdone is 2
                    {
                        if (sceneName == "Scene1") //checks if sceneName is equal to Scene1
                        {
                            QuestText.GetComponent<Text>().text = "There's my favorite ball! "; //sets QuestText to There's my favorite ball!
                            questDone = 3; //sets questDone to 3
                        }

                        else if (sceneName == "Scene2") //checks if sceneName is equal to Scene1
                        {
                            QuestText.GetComponent<Text>().text = "AH! So good! Thank you!"; //sets QuestText to AH! So good! Thank you!
                            questDone = 3; //sets questDone to 3
                        }

                        else if (sceneName == "Scene3") //checks if sceneName is equal to Scene1
                        {
                            QuestText.GetComponent<Text>().text = "MY HEART!... THANK YOU!"; //sets QuestText to MY HEART!... THANK YOU!
                            questDone = 3; //sets questDone to 3
                        }

                    }

                }

                questActive = true; //sets questActive to true
                GetComponentInChildren<Animator>().SetTrigger("Talk"); //triggers Talk for the animator component located in a child of this object
                talking = true; //sets talking to true

                QuestText.SetActive(true); //sets active the QuestText

                if (questDone == 0) //checks if questDone is 0
                {
                    questDone = 1; //sets questDone to 1
                }
                else if (questDone == 1 && sceneName == "Scene1") //checks if questDone is 1 and if sceneName is Scene1
                {
                    QuestText.GetComponent<Text>().text = "Have you found my ball?"; //sets QuestText to Have you found my ball?
                }
                else if (questDone == 1 && sceneName == "Scene2") //checks if questDone is 1 and if sceneName is Scene2
                {
                    QuestText.GetComponent<Text>().text = "Im so thirsty! Where is that elixir?"; //sets QuestText to Im so thirsty! Where is that elixir?
                }
                else if (questDone == 1 && sceneName == "Scene3") //checks if questDone is 1 and if sceneName is Scene3
                {
                    QuestText.GetComponent<Text>().text = "My heart! Where is it?"; //sets QuestText to My heart! Where is it?
                }
            }
            transform.LookAt(other.transform); //transforms this object to look at other collider
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") //checks if others tag is Player
        {
            MyAgent.destination = transform.position; //sets destination to its Immediate position
            if (talking) //checks if talking
            {
                GetComponentInChildren<Animator>().SetTrigger("NotTalk"); //triggers NotTalk for the animator component located in a child of this object
                talking = false; //sets talking to false
                QuestText.SetActive(false); //sets active the QuestText
            }
        }
    }
}
