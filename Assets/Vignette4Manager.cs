using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using _Wormcatcher.Scripts.GameplayManagers;
using _Wormcatcher.Scripts.Inputs;
using _Wormcatcher.Scripts.Interaction.SceneObjects;
using UnityEngine;

public class Vignette4Manager : VignetteManager
{
    [SerializeField] private Transform spawn;

    [Header("SpawnParams")]
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private StepSoundManager2 stepSoundManager2;
    [SerializeField] private SceneObjectHandler sceneObjectHandler; 
    public override void ChangeToApartment()
    {
        SceneLoader.SwitchScene(5);
    }
    
    private void Awake()
    {
        if (overrideSpawnPoints)
        {
            playerMovement.Active = true;
            return;
        }
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;
        playerMovement.Active = true; 
    }
    
    
}
