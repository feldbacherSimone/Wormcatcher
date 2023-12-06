using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// Base Class for conditional interaction, triggers one interaction if conditions is true and nother if condition is false
    /// if a condition is unassigned, nothing will happen
    /// </summary>
    [System.Serializable]
    public abstract class ConditionalInteraction : InteractionObject
    {
        [FormerlySerializedAs("trueInteractionGameObject")] [SerializeField]
        private InteractionObject trueInteractionObject;

        [FormerlySerializedAs("falseInteractionGameObject")] [SerializeField]
        private InteractionObject falseInteractionObject;


        private void Awake()
        {
            trueInteractionObject.Active = false;
            if(falseInteractionObject != null)
                falseInteractionObject.Active = false; 
        }

        public override void Interact()
        {
            DebugPrint($"Conditoinal Interaction called in {this.name}, condition = {InteracionCondition()}");
            if (InteracionCondition())
            {
                CallInteraction(trueInteractionObject);
            }
            else
            {
                CallInteraction(falseInteractionObject);
            }
        }

        private void CallInteraction(InteractionObject interactionObject)
        {
            if(interactionObject == null)
                return;
            DebugPrint($"{InteracionCondition()} interaction calling {interactionObject.name}");
            interactionObject.Active = true;
            interactionObject.Interact();
            interactionObject.Active = false;
        }

        protected abstract bool InteracionCondition();
    }
}