using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float Crystals; //instantiates a float named Crystals
    public GameObject player; //instantiates a GameObject named player
    public Text CrystalText; //instantiates a Text named CrystalText
    public Slider HealthBar;//instantiates a Slider named HealthBar
    public Scene CurrentScene; //instantiates a Scene named CurrentScene
    public int SceneNum; //instantiates an int named SceneNum
    public int lives = 3; //instantiates an int named lives and sets it to 3

    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene(); //sets CurrentScene equal to the active scene
        SceneNum = PlayerPrefs.GetInt("Scene"); //sets SceneNum to the saved Scene number in Scene

            player = GameObject.FindGameObjectWithTag("Player"); //sets player equal to the object with the tag Player
            Crystals = PlayerPrefs.GetFloat("Currency"); //sets Crystals to the saved number in Currency
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Health = PlayerPrefs.GetFloat("PlayerHealth"); //sets Health located in the object with the tag Player in its Player script component equal to the saved number in PlayerHealth
            HealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>(); //sets HealthBar equal to the object with the tag HealthBar Slider component
            CrystalText = GameObject.FindGameObjectWithTag("CrystalText").GetComponent<Text>(); //sets CrystalText equal to the object with the tag CrystalText Text component 

    }

    // Update is called once per frame
    void Update()
    {

            CrystalText.text = "Crystals: " + Crystals; //sets CrystalText's text to "Crystals" concadinated with Crystals
            HealthBar.value = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Health; //Sets HealthBars value equal Health located in the object with the tag Player, Player component
        PlayerPrefs.SetFloat("Currency", Crystals); // Sets "Currency" to Crystals to be saved
        if (lives <= 0)// checks if lives is less than or equal to 0
        {
            SceneManager.LoadScene("LoseScene"); //loads the scene named LoseScene
        }
    }

    public void Death()
    {

        player.transform.position = GameObject.FindGameObjectWithTag("Save").GetComponent<Save>().CurrentSavePoint; //Sets players position to the CurrentSavePoint position located in the object with the tag Save, Save component
        player.GetComponent<Player>().Health = 100; //Sets Health located in player's Player script component to 100
        lives -= 1; //decreases lives by 1

    }

    public void NextLevel()
    {
        SceneNum++;
        SceneManager.LoadScene(SceneNum); //loads the scene in the SceneNum position in the build Index
        PlayerPrefs.SetInt("Scene", SceneNum); //sets Scene to SceneNum to save
        PlayerPrefs.SetFloat("Currency", Crystals); // Sets "Currency" to Crystals to be saved
        PlayerPrefs.SetFloat("PlayerHealth", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Health); //Sets PlayerHealth to Health located in the game object with the tag Player in the Player Script component to be saved
        player.transform.position = GameObject.FindGameObjectWithTag("StartPoint").transform.position; //sets players position to the position of the game object with the tag StartPoint

    }

    public void LoadSave()
    {
        if (SceneNum >= 1 && SceneNum < SceneManager.sceneCountInBuildSettings) //checks if currentlevel is greater than or equal to 1 and if current level is less than 4
        {
            SceneManager.LoadScene(SceneNum);//reloads currentlevel
        }
    }

    public void StartNew()
    {
        SceneNum = 1; //sets SceneNum to 1
        PlayerPrefs.SetInt("Scene", SceneNum); //Sets Scene to SceneNum to be saved
        SceneManager.LoadScene(1); //loads scene 1 in the build index
        Crystals = 0; //sets Crystals to 0
        player.GetComponent<Player>().Health = 100; //sets Health located in player's Player script to 100
        player.transform.position = GameObject.FindGameObjectWithTag("StartPoint").transform.position; //sets players position to the position of the game object with the tag StartPoint
    }
}
