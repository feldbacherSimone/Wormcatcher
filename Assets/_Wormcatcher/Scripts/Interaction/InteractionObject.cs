
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public abstract class InteractionObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool debug;

        private Collider collider;

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
            Debug.LogError($"No Interaction Defined in {this.name}");
        }
    }
}