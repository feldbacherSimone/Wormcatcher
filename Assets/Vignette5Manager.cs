using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using _Wormcatcher.Scripts.GameplayManagers;
using _Wormcatcher.Scripts.Inputs;
using _Wormcatcher.Scripts.Interaction.SceneObjects;
using UnityEngine;

public class Vignette5Manager : VignetteManager
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CanvasGroup mouseIcon;
    private void Awake()
    {
        if (overrideSpawnPoints)
        {
            playerMovement.Active = true;
            return;
        }
        
        player.transform.position = spawnPositions[PlayerData.V1Progress].position;
        player.transform.rotation = spawnPositions[PlayerData.V1Progress].rotation;
        playerMovement.Active = true;
        ShowLeftClickIcon();
    }

    public override void ChangeToApartment()
    {
        throw new System.NotImplementedException();
    }
    
    public void ShowLeftClickIcon()
    {
        StartCoroutine(ShowLeftClickIconInternal());
    }
    
    IEnumerator ShowLeftClickIconInternal()
    {
        yield return new WaitForSeconds(6);
   
        StartCoroutine(TextEffects.FadeIn(mouseIcon, 2.0f,
            () =>
            {
                StartCoroutine(TextEffects.FadeOut(mouseIcon, 2, () =>
                {
                    
                }));
            }));
    }

    public void EndVignette5()
    {
        SceneLoader.SwitchScene(6);
    }
}
