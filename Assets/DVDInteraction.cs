using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts.Interaction;
using _Wormcatcher.Scripts.Interaction.SceneObjects;
using UnityEngine;

public class DVDInteraction : InteractionObject
{
    [SerializeField] private string nodeName;

    [SerializeField] private SceneObjectHandler sceneObjectHandler;

    public override void Interact()
    {
    }
}