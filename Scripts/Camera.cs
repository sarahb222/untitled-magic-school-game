using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        //Find the player
        player = GameObject.FindWithTag("Player");

        //Make the camera follow the player
        vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = player.transform;
    }

}
