using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using _Wormcatcher.Scripts.Inputs;
using UnityEngine;

public class Vignette1Manager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;

    [SerializeField] private bool overrideSpawnPoints;

    public void ChangePosition(int i)
    {
        PlayerData.Vignette1Position = i;
    }

    private void Start()
    {
        CheckSpawn();
    }

    private void CheckSpawn()
    {
        if (overrideSpawnPoints) return;
        
        player.transform.position = spawnPositions[PlayerData.Vignette1Position].position;
        player.transform.rotation = spawnPositions[PlayerData.Vignette1Position].rotation;
        switch (PlayerData.Vignette1Position)
        {
            case 1:
                playerMovement.DisableWalk();
                mouseLook.SetLookAngle(100, spawnPositions[1].rotation.eulerAngles.y);
                break;
            default: 
                break;
        }
    }

    public void ChangeToMudroom(float time)
    {
        ChangePosition(1);
        SceneLoader.SwitchScene(1);
    }
}