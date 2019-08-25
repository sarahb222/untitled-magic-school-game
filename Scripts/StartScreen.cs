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

    // Start is called before the first frame update
    void Start()
    {
        //Extra stuff is here so I can test game without having to go to start screen first

        saveFileName = Application.persistentDataPath + "/gamesave.save";
        if (newGame != null)
        {
            Button btnNew = newGame.GetComponent<Button>();
            btnNew.onClick.AddListener(newGameOnClick);
        }
        
        if (loadGame != null)
        {
            Button btnLoad = loadGame.GetComponent<Button>();
            btnLoad.onClick.AddListener(loadGameOnClick);
        }

        if (startNewGame != null)
        {
            Button btnStartNew = startNewGame.GetComponent<Button>();
            btnStartNew.onClick.AddListener(startNewGameOnClick);
        }

        if (returnPrev != null)
        {
            Button btnReturn = returnPrev.GetComponent<Button>();
            btnReturn.onClick.AddListener(returnOnClick);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void newGameOnClick()
    {
        startNew.SetActive(true);
    }

    void startNewGameOnClick()
    {
        if(name != null)
        {
            if(nameField.text != null && nameField.text.Length <= 12)
            {
                playerName = nameField.text;
                createNewGame = true;
                saveFileName = Application.persistentDataPath + "/gamesave.save";
                SceneManager.LoadScene("Schoolgrounds");
            }
            
        }
        
    }

    void loadGameOnClick()
    {
        saveFileName = Application.persistentDataPath + "/gamesave.save";
        SceneManager.LoadScene("Schoolgrounds");
    }

    void returnOnClick()
    {
        startNew.SetActive(false);
    }
}
