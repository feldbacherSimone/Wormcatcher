
using System;
using UnityEngine;

namespace _Wormcatcher.Scripts

/***
 * Base class for all interactions, implements the IInteractable interface, Interact() is called when the player interacts with an object.
 * Also handles showing debug messages, check the bool "debug" in inspector to show logs for a specific object 
 */
{
    public abstract class InteractionObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool debug;

        private Collider collider;
        [SerializeField]private bool active = true;

        public bool Active
        {
            get => active;
            set => active = value;
        }

        

        protected void Reset()
        {
            collider = GetComponent<Collider>();
            if (collider == null)
            {
                collider = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
            }
        }

        public void DebugPrint(string msg)
        {
            if (debug)
            {
                Debug.Log(msg);
            }
        }

        public virtual void Interact()
        {

        }
    }
}