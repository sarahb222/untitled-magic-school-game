using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public Button newGame = null;
    public Button loadGame = null;
    public Button startNewGame = null;
    public Button returnPrev = null;
    public GameObject startNew = null;
    public InputField nameField = null;
    public bool createNewGame = false;
    public String saveFileName;
    public String playerName;
    public static StartScreen Instance { get; set; }

    // Start is called before the first frame update
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

        //Extra if statements are here so I can test game without having to go to start screen first

        saveFileName = Application.persistentDataPath + "/gamesave.save";
        if (newGame != null)
        {
            //Create the new game button
            Button btnNew = newGame.GetComponent<Button>();
            btnNew.onClick.AddListener(NewGameOnClick);
        }
        
        if (loadGame != null)
        {
            //Create the load game button
            Button btnLoad = loadGame.GetComponent<Button>();
            btnLoad.onClick.AddListener(LoadGameOnClick);
        }

        if (startNewGame != null)
        {
            //Create the start new game button
            Button btnStartNew = startNewGame.GetComponent<Button>();
            btnStartNew.onClick.AddListener(StartNewGameOnClick);
        }

        if (returnPrev != null)
        {
            //Create the return button
            Button btnReturn = returnPrev.GetComponent<Button>();
            btnReturn.onClick.AddListener(ReturnOnClick);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void NewGameOnClick()
    {
        //Make the character creation screen show to player
        startNew.SetActive(true);
    }

    void StartNewGameOnClick()
    {
        if(name != null)
        {
            //User sets character name, must be between 0 and 13 characters
            if (nameField.text != null) {
                if (nameField.text.Length > 0 && nameField.text.Length <= 12)
                {
                    playerName = nameField.text;
                    createNewGame = true;

                    //Set the save file name
                    saveFileName = Application.persistentDataPath + "/gamesave.save";

                    //Load the scene to start playing
                    SceneManager.LoadScene("Schoolgrounds");
                }

            }
            
        }
        
    }

    //Load an existing game
    void LoadGameOnClick()
    {
        saveFileName = Application.persistentDataPath + "/gamesave.save";
        SceneManager.LoadScene("Schoolgrounds");
    }

    //Remove the character creation screen from view
    void ReturnOnClick()
    {
        startNew.SetActive(false);
    }
}
