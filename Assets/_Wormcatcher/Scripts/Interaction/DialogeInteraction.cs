using System;
using UnityEngine;
using Yarn.Unity;

namespace _Wormcatcher.Scripts
{
    public class DialogeInteraction : InteractionObject
    {
        [SerializeField] private String startNode;
        [SerializeField] private DialogueRunner dialogueRunner; 
        
        public override void Interact()
        {
            if(!Active)
                return;
            
            base.Interact();
            dialogueRunner.StartDialogue(startNode);
            Active = false; 
        }
    }
}