using System;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public abstract class ConditionalInteraction : InteractionObject, IInteractable
    {

        [SerializeField] private GameObject trueInteractionGameObject;
        [SerializeField] private GameObject falseInteractionGameObject;

        private IInteractable trueInteraction;
        private IInteractable falseInteraction;

        private void Awake()
        {
            if (!InteractablesNotNull())
            {
                Debug.LogError($"No Interactables found on {gameObject.name}. Check {nameof(trueInteractionGameObject)} and {nameof(falseInteractionGameObject)}");

            }
        }

        public void Interact()
        {
            if(GetCondition())
                trueInteraction?.Interact();
            else
            {
                falseInteraction?.Interact();
            }
        }

        protected abstract bool GetCondition();

        private bool InteractablesNotNull()
        {
            return trueInteractionGameObject != null && falseInteractionGameObject != null &&
                    trueInteractionGameObject.TryGetComponent<IInteractable>(out trueInteraction) &&
                   falseInteractionGameObject.TryGetComponent<IInteractable>(out falseInteraction);
        }
    }
}