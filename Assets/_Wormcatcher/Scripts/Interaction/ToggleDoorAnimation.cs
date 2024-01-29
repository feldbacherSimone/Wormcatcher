using UnityEngine;
using UnityEngine.Events;

namespace _Wormcatcher.Scripts.Interaction
{
    public class ToggleDoorAnimation : ToggleAnimation
    {
        [SerializeField] private UnityEvent openEvent;
        [SerializeField] private UnityEvent closeEvent;

        public override void Interact()
        {
            if(!Active)
                return;
            
            base.Interact();
            animator.SetTrigger(interactTrigger);
            
            DebugPrint(gameObject.name + " interacted, animationOn = " + isOpen);
            
            if(isOpen){closeEvent.Invoke();}
            else{openEvent.Invoke();}
        }
    }
}