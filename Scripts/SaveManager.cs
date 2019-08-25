﻿using System.Collections;
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

    void Start()
    {
        if(GameObject.Find("StartLocation").GetComponent<StartScreen>().createNewGame == false)
        {
            LoadGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //For loading the game, remove once real functionality exists
        if (Input.GetKeyDown("x"))
        {
            LoadGame();
        }

    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.days = clock.days;
        save.seasons = clock.seasons;
        save.years = clock.years;
        save.playerSkills = skillMaster.playerSkills.playerSkills;
        save.playerName = GameObject.Find("Player").GetComponent<Player>().myName;

        return save;
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GameObject.Find("SaveLocation").GetComponent<StartScreen>().saveFileName);
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(GameObject.Find("SaveLocation").GetComponent<StartScreen>().saveFileName, FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            clock.days = save.days;
            clock.seasons = save.seasons;
            clock.years = save.years;
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

    public void YesSave()
    {
        clock.days = clock.days + 1;
        clock.hours = 6;
        clock.minutes = 0;
        clock.UpdateTime();
        SaveGame();
        saveOption.SetActive(false);
    }

    public void NoSave()
    {
        saveOption.SetActive(false);
    }
}
