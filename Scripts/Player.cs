using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private SaveManager save;
    public SkillMaster skillMaster;

    void Start()
    {
        //Allows player to move
        this.InitializeMovement();

        //Sets player name
        if (this.myName.Length == 0)
        {
            this.myName = GameObject.Find("StartLocation").GetComponent<StartScreen>().playerName;
        }

        //Don't get rid of the player if a scene loads
        DontDestroyOnLoad(this.gameObject);
    }
    
    //When the player is colliding with something
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Save and sleep while colliding with the bed
        if (Input.GetKeyDown("space") && collision.gameObject.name == "Bed"){
            save = GameObject.Find("UI").GetComponent<SaveManager>();
            save.saveOption.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move character every time it is updated if buttons are pressed
        this.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));


        //REMOVE THIS it just tests adding to stat!!
        if (Input.GetKeyDown("v"))
        {
            skillMaster.playerSkills.playerSkills.earth.level++;
        }
    }
}
