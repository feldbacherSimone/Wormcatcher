using UnityEngine;
using UnityEngine.Events;

namespace _Wormcatcher.Scripts.Interaction
{
    public class DummyInteraction : InteractionObject
    {
        [SerializeField] private UnityEvent interactEvent; 
        public override void Interact()
        {
            interactEvent.Invoke();
        }
    }
}