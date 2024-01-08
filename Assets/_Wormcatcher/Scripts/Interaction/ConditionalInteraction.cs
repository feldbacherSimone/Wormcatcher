using System;
using UnityEngine;
using UnityEngine.Events;
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

        [Header("Unity Events")] //Use these to call sounds and so on
        [SerializeField]private UnityEvent trueInteractionEvent;
        [SerializeField]private UnityEvent falseInteractionEvent;
        
        [Header("Interaction Overrides")] //Use these if eg. a door should always be locked but still rattle
        [SerializeField]private bool alwaysSendTrue = false;
        [SerializeField]private bool alwaysSendFalse = false;

        private void Awake()
        {
            trueInteractionObject.Active = false;
            if(falseInteractionObject != null)
                falseInteractionObject.Active = false; 
        }

        public override void Interact()
        {
            DebugPrint($"Conditoinal Interaction called in {this.name}, condition = {InteractionCondition()}");
            
            //Send condition data. Overriden by alwaysSendFalse and alwaysSendTrue. False takes priority.
            if (alwaysSendFalse)
            {
                CallInteraction(falseInteractionObject);
                falseInteractionEvent.Invoke();
            }
            else if (InteractionCondition() || alwaysSendTrue)
            {
                CallInteraction(trueInteractionObject);
                trueInteractionEvent.Invoke();
            }
            else if (!InteractionCondition())
            {
                CallInteraction(falseInteractionObject);
                falseInteractionEvent.Invoke();
            }
        }

        private void CallInteraction(InteractionObject interactionObject)
        {
            if(interactionObject == null)
                return;
            DebugPrint($"{InteractionCondition()} interaction calling {interactionObject.name}");
            interactionObject.Active = true;
            interactionObject.Interact();
            interactionObject.Active = false;
        }

        protected abstract bool InteractionCondition();
    }
}