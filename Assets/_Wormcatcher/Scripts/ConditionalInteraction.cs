using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Wormcatcher.Scripts
{
    [System.Serializable]
    public abstract class ConditionalInteraction : InteractionObject
    {
        [FormerlySerializedAs("trueInteractionGameObject")] [SerializeField]
        private InteractionObject trueInteractionObject;

        [FormerlySerializedAs("falseInteractionGameObject")] [SerializeField]
        private InteractionObject falseInteractionObject;


        public override void Interact()
        {
            DebugPrint($"Conditoinal Interaction called in {this.name}, condition = {GetCondition()}");
            if (GetCondition())
            {
                DebugPrint($"True interaction calling {trueInteractionObject.name}");
                trueInteractionObject?.Interact();
            }
            else
            {
                falseInteractionObject?.Interact();
            }
        }

        protected abstract bool GetCondition();
    }
}