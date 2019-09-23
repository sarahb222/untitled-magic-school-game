using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    public ClockScript clock;
    public GameObject saveOption;
    public Button yesSave;
    public Button noSave;
    public SkillMaster skillMaster;
    public static SaveManager Instance { get; set; }

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //If the player needs to load the game, then load it!
        if (GameObject.Find("StartLocation") != null &&
           GameObject.Find("StartLocation").GetComponent<StartScreen>().loadMyGame == true)
        {
            GameObject.Find("StartLocation").GetComponent<StartScreen>().loadMyGame = false;
            LoadGame();
        }
        //For loading the game quickly, remove once no longer needed
        if (Input.GetKeyDown("x"))
        {
            LoadGame();
        }

    }

    //Creating the save game object for saving
    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.days = clock.days;
        save.season = clock.season;
        save.years = clock.years;
        save.dayoftheWeek = clock.dayoftheWeek;
        save.playerSkills = skillMaster.playerSkills.playerSkills;
        save.playerName = GameObject.Find("Player").GetComponent<Player>().myName;

        return save;
    }

    //Save the game!
    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GameObject.Find("StartLocation").GetComponent<StartScreen>().saveFileName);
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }

    //Load the game!
    public void LoadGame()
    {
        if (File.Exists(GameObject.Find("StartLocation").GetComponent<StartScreen>().saveFileName))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(GameObject.Find("StartLocation").GetComponent<StartScreen>().saveFileName, FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            clock.days = save.days;
            clock.season = save.season;
            clock.years = save.years;
            clock.dayoftheWeek = save.dayoftheWeek;
            clock.minutes = 0;
            clock.hours = 6;
            skillMaster.playerSkills.playerSkills = save.playerSkills;
            GameObject.Find("Player").GetComponent<Player>().myName = save.playerName;

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    //If the player chooses to save the game, then save the game
    public void YesSave()
    {
        clock.days = clock.days + 1;
        clock.hours = 6;
        clock.minutes = 0;
        //Update the day of the week
        if (clock.dayoftheWeek == "Sunday")
        {
            clock.dayoftheWeek = "Monday";
        } else if (clock.dayoftheWeek == "Monday")
        {
            clock.dayoftheWeek = "Tuesday";
        } else if (clock.dayoftheWeek == "Tuesday")
        {
            clock.dayoftheWeek = "Wednesday";
        } else if (clock.dayoftheWeek == "Wednesday")
        {
            clock.dayoftheWeek = "Thursday";
        } else if (clock.dayoftheWeek == "Thursday")
        {
            clock.dayoftheWeek = "Friday";
        } else if (clock.dayoftheWeek == "Friday")
        {
            clock.dayoftheWeek = "Saturday";
        } else {
            clock.dayoftheWeek = "Sunday";
        }
            clock.UpdateTime();
        SaveGame();
        saveOption.SetActive(false);
    }

    //If the user does not want to save the game, close out of option box
    public void NoSave()
    {
        saveOption.SetActive(false);
    }
}
