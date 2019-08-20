using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private ClockScript clock;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        clock = GameObject.Find("UI").GetComponent<ClockScript>();
        //Save the game!
        if (Input.GetKeyDown("space") && collision.gameObject.name == "Bed"){
            clock.saveOption.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}
