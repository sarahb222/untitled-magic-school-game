using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    private SaveManager save;
    public SkillMaster skillMaster;
    public bool paused = false;
    public GameObject pauseScreen;

    void Start()
    {
        //Allows player to move
        this.InitializeMovement();

        //Sets player name
        if (this.myName.Length == 0 && GameObject.Find("StartLocation") != null)
        {
            this.myName = GameObject.Find("StartLocation").GetComponent<StartScreen>().playerName;
        }

        //Don't get rid of the player if a scene loads
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;

        if (Input.GetButtonDown("Cancel") && !pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
            paused = true;
        }
        else if(Input.GetButtonDown("Cancel") && pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(false);
            paused = false;
        }
        
        //Move character every time it is updated if buttons are pressed
        if(paused == false)
        {
            this.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
        else
        {
            this.Move(new Vector2(0,0));
        }
    }
    
    //Teleports character after the scene has changed, this code fixes a glitch where character would teleport briefly and then teleport back to the position from the previous scene
    private void ChangedActiveScene(Scene current, Scene next)
    {
        this.TeleportTo(GameObject.Find("GatewayManager").GetComponent<GatewayManager>().spawnPosition);
    }
}
