using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


public class ClockScript : MonoBehaviour
{
    private float inGameMinute = 1; // How many seconds is a real time minute
    private static GameObject instance;

    private System.TimeSpan gameTime;
    public int years = 1;
    public int seasons = 1;
    public int days = 1;
    public int hours = 0;
    public int minutes = 0;
    public Text time;
    public Image nighttime;
    public GameObject saveOption;
    public Button yesSave;
    public Button noSave;

    IEnumerator Start()
    {
        hours = 6;
        

        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this.gameObject;
            while (true)
            {
                yield return new WaitForSecondsRealtime(inGameMinute);
                //In Game Minute Passed. Do Something
                minutes = minutes + 1;

                UpdateTime();
                
                GetTime();
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
        
    

    public System.TimeSpan GetTime()
    {

        gameTime = new System.TimeSpan((int)hours, (int)minutes, 0);
        return gameTime;
    }

    void FixedUpdate()
    {
        time.text = "Year: " + years + " Season: " + seasons + " Day: " + days + " " + GetTime().ToString();

        Scene scene = SceneManager.GetActiveScene();

        if ((hours >= 18 || hours < 6)  && (scene.name == "Schoolgrounds"))
        {
            nighttime.enabled = true; ;
        }
        else
        {
            nighttime.enabled = false;
        }
        
        //For loading the game, remove once real functionality exists
        if (Input.GetKeyDown("x"))
        {
            LoadGame();
        }

    }

    public void UpdateTime()
    {
        if (minutes == 60)
        {
            hours = hours + 1;
            minutes = 0;
        }
        if (hours == 24)
        {
            hours = 0;
            days = days + 1;
        }
        if (days == 22)
        {
            days = 1;
            seasons = seasons + 1;
        }
        if (seasons == 5)
        {
            seasons = 1;
            years = years + 1;
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.days = days;
        save.seasons = seasons;
        save.years = years;

        return save;
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            
            days = save.days;
            seasons = save.seasons;
            years = save.years;
            minutes = 0;
            hours = 6;

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    public void YesSave()
    {
        days = days + 1;
        hours = 6;
        minutes = 0;
        UpdateTime();
        SaveGame();
        saveOption.SetActive(false);
    }

    public void NoSave()
    {
        saveOption.SetActive(false);
    }
    
}
