using System;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

namespace _Wormcatcher.Scripts.Interaction
{
    public class DialogeInteraction : InteractionObject
    {
        [SerializeField] private String startNode;
        [SerializeField] private DialogueRunner dialogueRunner;

        [SerializeField] private bool useCondition;
        [SerializeField] private PlayerAction condition;
        [SerializeField] private UnityEvent interactEvent; 
        public override void Interact()
        {
            if(!Active ||(useCondition && !PlayerData.GetActionValue(condition)))
                return;
            
            base.Interact();
            dialogueRunner.StartDialogue(startNode);
            interactEvent.Invoke();
            Active = false; 
        }
    }
}