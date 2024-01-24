using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;

public class Vignette1Manager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;

    [SerializeField] private GameObject player;

    public void ChangePosition(int i)
    {
        PlayerData.Vignette1Position++; 
    }

    private void Start()
    {
        player.transform.position = spawnPositions[PlayerData.Vignette1Position].position;
    }
}
