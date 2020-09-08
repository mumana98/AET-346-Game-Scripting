using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public float horizontalSpeed; //Instantiates a float named horizontalSpeed
    public float speed;//Instantiates a float named speed
    public bool grounded = false; //Instantiates a boolean named grounded and sets it to false
    private GameObject[] enemies; //Instantiates a GameObject array name enemies
    public float Health = 100; //Instantiates a float named Health and sets it to 100

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); //sets enemies equal to all game objects with the tag Enemy
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); //sets enemies equal to all game objects with the tag Enemy
        if (Input.GetKeyDown(KeyCode.Space) && grounded) //checks if the player has the spacebar pressed
        {
            grounded = false; //sets grounded to false
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 250); //adds force to the player's y-axis by 300
            gameObject.GetComponentInChildren<Animator>().SetTrigger("jump"); //triggers jump in the child Animator component
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && grounded
        ) //checks if the player is currently pressing the key A or the left arrow
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime *
                                           speed); //adds force to the player's x-axis by speed going left
            gameObject.GetComponentInChildren<Animator>().SetTrigger("run");//triggers run in the child Animator component
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && grounded
        ) //checks if the player is currently pressing the key D or the right arrow
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime *
                                           speed); //adds force to the player's x-axis by speed going right
            gameObject.GetComponentInChildren<Animator>().SetTrigger("run");//triggers run in the child Animator component
        }

        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && grounded
        ) //checks if the player is currently pressing the key W or the up arrow
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime *
                                           speed); //adds force to the player's z-axis by speed going forward
            gameObject.GetComponentInChildren<Animator>().SetTrigger("run");//triggers run in the child Animator component
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && grounded
        ) //checks if the player is currently pressing the key S or the down arrow
        {
            gameObject.transform.Translate(Vector3.back * Time.deltaTime *
                                           speed); //adds force to the player's z-axis by speed going backwards
            gameObject.GetComponentInChildren<Animator>().SetTrigger("run");//triggers run in the child Animator component
        }
        else if (Input.GetMouseButtonDown(0)) //checks if mouse if clicked
        {
            gameObject.GetComponentInChildren<Animator>().SetTrigger("attack");//triggers attack in the child Animator component
        }
        else
        {
            gameObject.GetComponentInChildren<Animator>().SetTrigger("idle");//triggers idle in the child Animator component
        }

        if (Input.GetKey(KeyCode.R)) //checks if R is pressed
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Death(); //invokes the Death function located in the game object with the tag GameController in its GameManager script
        }

        float
            h = horizontalSpeed *
                Input.GetAxis(
                    "Mouse X"); //instantiates a float named h and sets it equal to horizontalSpeed multiplied by the mouses x axis movement
        transform.Rotate(0, h, 0); //rotates the object this script is applied to horizontally by h  

        if (Health <= 0) //checks if Health is less than or equal to 0
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Death();//invokes the Death function located in the game object with the tag GameController in its GameManager script
        }

        foreach (GameObject g in enemies) //goes through all game objects in the enemies array
        {

            if ((Vector3.Distance(gameObject.transform.position, g.transform.position) < 2) &&
                Input.GetMouseButtonDown(0)) //checks if the distance from the game object this script is attached to, to the game object in the g position of the enemies array position is less than 2 and if the mouse is clicked
            {
                g.GetComponent<Enemy>().EnemyHealth -= 10; // decreases EnemyHealth located in g's Enemy script component by 10
            }

        }
    }

    void OnTriggerStay(Collider other)
        {
            if (other.tag == "Ground") //checks if others tag is Ground
            {
                grounded = true; //sets grounded to true
            }

        }


    }
