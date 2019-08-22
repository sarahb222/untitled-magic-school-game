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

        player = GameObject.FindWithTag("Player");

        vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = player.transform;

    }

}
