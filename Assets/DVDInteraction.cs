using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using _Wormcatcher.Scripts.Interaction;
using _Wormcatcher.Scripts.Interaction.SceneObjects;
using UnityEngine;
using Yarn.Unity;

public class DVDInteraction : InteractionObject
{
    [SerializeField] private string nodeName;
    [SerializeField] private bool celvici; 
    [SerializeField] private DialogueRunner dialogueRunner; 

    [SerializeField] private SceneObjectHandler sceneObjectHandler;
    [SerializeField] private GameObject original;
    [SerializeField] private SceneObject sceneObject;

    [SerializeField] private TVSwitcher tvSwitcher; 
    private bool dvdActive; 
    public override void Interact()
    {
        if(sceneObjectHandler.SceneObject != null || !PlayerData.GetActionValue(PlayerAction.FinishedDialogueV3)) return;
        
        original.SetActive(false);
        sceneObjectHandler.SceneObject = sceneObject;
        sceneObjectHandler.AlwaysActive = true; 
        sceneObjectHandler.SpawnObject();
        
        dialogueRunner.StartDialogue(nodeName);
        dvdActive = true;
        if (celvici)
        {
            tvSwitcher.Active = true; 
        }
    }

    public void PutDvdDown()
    {
        if(!dvdActive) return;
        sceneObjectHandler.AlwaysActive = false; 
        sceneObjectHandler.DespawnObject();
        sceneObjectHandler.SceneObject = null; 
        original.SetActive(true);
        sceneObjectHandler.DestroySceneObject();
        dvdActive = false;
    }
}