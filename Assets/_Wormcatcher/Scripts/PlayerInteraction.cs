using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Wormcatcher.Scripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActionAsset;
        [SerializeField] GameObject selectionResponseObject;
        private ISelectableObject selectionResponse; 
        
        private InputAction interactAction;

        [SerializeField] private float interactionDistance = 10f;

        [SerializeField] private Boolean debug; 
        private RaycastHit hit;
        private IInteractable interactable;
        
        private GameObject interactionObject;
        

        private void Awake()
        {
            InputActionMap inputActionMap = inputActionAsset.FindActionMap("KeyboardMovement");
            interactAction = inputActionMap.FindAction("Interact");
            selectionResponse = selectionResponseObject.GetComponent<ISelectableObject>();
        }

        private void OnEnable()
        {
            interactAction.Enable();
        }

        private void Update()
        {
            CheckForSelectable();
            if (interactable != null)
            {
                interactionObject = hit.transform.gameObject;
                DebugPrint("Found Interactable " + interactable + "Interaction Object " + interactionObject);
                selectionResponse.OnSelect(interactionObject);
                if(interactAction.triggered)
                    interactable.Interact(); DebugPrint("interaction Triggered");
            }
            else if (interactionObject != null)
            {
                selectionResponse.OnDeselect(interactionObject);
                interactionObject = null;
            }
        }

        private InteractionObject CheckForSelectable()
        {
            DebugRay(transform.position, transform.forward * interactionDistance, Color.cyan);
            
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
            {
                DebugRay(transform.position, transform.forward * interactionDistance, Color.red);
                interactable = hit.transform.GetComponent<IInteractable>();
            }
            else
            {
                interactable = null; 
                
            }
        }

        #region Debugging
        private void DebugRay(Vector3 position, Vector3 dir, Color color)
        {
            if(debug)
                Debug.DrawRay(position, dir, color);
        }
    
        public void DebugPrint(string msg)
        {
            if (debug)
            {
                Debug.Log(msg);
            }
        }
        #endregion
    }
}
