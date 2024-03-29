﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GatewayManager : MonoBehaviour
{
    public Vector2 spawnPosition;
    private bool spawnPrepared;
    public static GatewayManager Instance { get; set; }

    // Use this for initialization
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += SceneLoaded;
    }

    //Move player if the spawn position is prepared
    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (spawnPrepared)
        {
            MovePosition();
        }
    }

    //Set the spawn position
    public void SetSpawnPosition(Vector2 spawnPosition)
    {
        spawnPrepared = true;
        this.spawnPosition = spawnPosition;
    }

    //Teleport player to the correct position
    private void MovePosition()
    {
        FindObjectOfType<Player>().TeleportTo(spawnPosition);
        spawnPrepared = false;
    }
}
