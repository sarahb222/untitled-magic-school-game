using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    private Animator playerAnim;
    private int direction = 0;

    // Use this for initialization
    void Start()
    {

        playerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            playerAnim.Play("PlayerBackWalk", 0);
            direction = 1;
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerAnim.Play("PlayerSideLeftWalk", 0);
            direction = 2;
        }

        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            playerAnim.Play("PlayerFrontWalk", 0);
            direction = 3;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerAnim.Play("PlayerSideWalk", 0);
            direction = 4;
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") ==0)
        {
            if (direction == 1) { playerAnim.Play("PlayerBackWalk", 0, 0f); }
            if (direction == 2) { playerAnim.Play("PlayerSideLeftWalk", 0, 0f); }
            if (direction == 3) { playerAnim.Play("PlayerFrontWalk", 0, 0f); }
            if (direction == 4) { playerAnim.Play("PlayerSideWalk", 0, 0f); }
        }

    }
}
