
using UnityEngine;
using System;


namespace _Wormcatcher.Scripts
{
    public class ToggleAnimation : InteractionObject
    {
        private bool animationOn = false;
        [SerializeField] private Animator animator;

        public void Reset()
        {
            if (animator == null)
            {
                animator = gameObject.AddComponent(typeof(Animator)) as Animator;
            }
            SetAnimationParent();
            base.Reset();
        }

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
            animationOn = !animationOn;
            animator.SetBool("animationOn", animationOn);
            DebugPrint(gameObject.name + " interacted, animationOn = " + animationOn);
            
        }
        
    }
}