using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    private SaveManager save;

    //When the player is colliding with the save object
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Save and sleep while colliding with the save object
            if (Input.GetKeyDown("space"))
            {
                save = GameObject.Find("UI").GetComponent<SaveManager>();
                save.saveOption.SetActive(true);
            }
        }
            
    }
}
