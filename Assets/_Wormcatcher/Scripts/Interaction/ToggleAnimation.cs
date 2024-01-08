
using UnityEngine;
using System;


namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// My try to trigger an animation when intercated.
    /// Automatically generats an animation parent (only way i got relative offsets to work) and an animator
    /// </summary>
    public class ToggleAnimation : InteractionObject
    {
        public bool isOpen = false;
        [SerializeField] private Animator animator;
        [SerializeField] private string interactTrigger = "Interact";
        [SerializeField] private string lockedBool = "Locked";
        

        public void Reset()
        {
            // create an animator component if necessary 
            if (animator == null)
            {
                animator = gameObject.AddComponent(typeof(Animator)) as Animator;
            }
            
            // create an animation parent so our own transforms are all 0,0,0 (to reuse animations, there probably a better way for this) 
            //SetAnimationParent();
            base.Reset();
        }
        
        /// <summary>
        /// Creates a new empty object and sets it as our parent, resets all of our transforms to 0
        /// This is used to make relative animations possible
        /// I define all of my animation clips to start from 0 as well 
        /// </summary>
        private void SetAnimationParent()
        {
            GameObject newParent = new GameObject
            {
                name = name + "AnimationParent",
                transform =
                {
                    position = transform.position,
                    rotation = transform.rotation
                }
            };
            Transform currentParent = transform.parent;

            transform.parent = null;
            newParent.transform.parent = currentParent;
            transform.parent = newParent.transform;

            transform.position.Set(0, 0, 0);
            transform.rotation.eulerAngles.Set(0, 0, 0);
        }

        public override void Interact()
        {
            if(!Active)
                return;
            
            base.Interact();
            animator.SetTrigger(interactTrigger);
            DebugPrint(gameObject.name + " interacted, animationOn = " + isOpen);
            
        }

        public void SetLocked(bool locked)
        {
            animator.SetBool(lockedBool, locked);
        }

        public void SetOpened(bool open)
        {
            isOpen = open;
        }
        
    }
}