using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class PickUpInteraction : InteractionObject
{
   [SerializeField] private ObjectManager objectManager;
   [SerializeField] private UnityEvent interactEvent; 
   public override void Interact()
   {
      base.Interact();
      objectManager.AddGameObject(name);
      interactEvent.Invoke();
      transform.parent.parent.gameObject.SetActive(false);
   }
}
