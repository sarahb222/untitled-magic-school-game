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
            playerAnim.Play("PlayerWalk");
        }
        else
        {
            playerAnim.Play("PlayerIdle", 0);
        }


    }
}
