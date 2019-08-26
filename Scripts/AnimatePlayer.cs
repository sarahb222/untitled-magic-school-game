using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    public SpriteRenderer sprite;
    private Animator playerAnim;

    // Use this for initialization
    void Start()
    {
        playerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Make sure the sprite faces the correct direction
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            sprite.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sprite.flipX = false;
        }
        
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            //If moving horizontally or vertically, play walking animation
            playerAnim.Play("PlayerWalk");
        }
        else
        {
            //Otherwise play idle animation
            playerAnim.Play("PlayerIdle", 0);
        }


    }
}
