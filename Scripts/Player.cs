using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private SaveManager save;
    public SkillMaster skillMaster;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        save = GameObject.Find("UI").GetComponent<SaveManager>();
        //Save the game!
        if (Input.GetKeyDown("space") && collision.gameObject.name == "Bed"){
            save.saveOption.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));


        //REMOVE THIS it just tests adding to stat!!
        if (Input.GetKeyDown("v"))
        {
            skillMaster.playerSkills.playerSkills.earth.level++;
        }
    }
}
