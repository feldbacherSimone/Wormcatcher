using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// Handles all the player input and logic for interacting with objects
    /// Assigned to the player controller, calls implementations of ISelectable and IInteractable 
    /// </summary>
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActionAsset;
        [SerializeField] GameObject selectionResponseObject;

        private PlayerInputAction playerInputAction;
        private ISelectionResponse selectionResponse;

        private InputAction interactAction;
        private InputAction sceneObjectAction;
        
        [Header("Ray Data")]
        [SerializeField] private float interactionDistance = 10f;

        [SerializeField] private Boolean debug;
        [SerializeField] private LayerMask hitMask;
        private RaycastHit hit;
        private IInteractable interactable;

        private GameObject selectableObject;
        


        private void Awake()
        {
            // fetch a selection response from the refernced object 
            selectionResponse = selectionResponseObject.GetComponent<ISelectionResponse>();

            // Enable interact input action 
            playerInputAction = new PlayerInputAction();
            playerInputAction.WalkInput.Enable();

            // Assign the scene object handler methods to the mouse click hold events
            playerInputAction.WalkInput.SceneObject.started += _ => SceneObjectHandler._instance.SpawnObject();
            playerInputAction.WalkInput.SceneObject.canceled += _ => SceneObjectHandler._instance.DespawnObject();
        }


        private void Update()
        {
            if (ValidObjectSelection() && playerInputAction.WalkInput.Interact.triggered)
            {
                interactable.Interact();
                DebugPrint("interaction Triggered");
            }
        }

        /// <summary>
        /// Check if an interactable Object is selected 
        /// </summary>
        /// <returns></returns>
        private bool ValidObjectSelection()
        {
            GameObject newSelectable = CheckForSelectable();
            // Deselect the current object if it's not the same as the new one
            if (selectableObject != null && newSelectable != selectableObject)
            {
                DeselectCurrentObject();
                selectableObject = newSelectable;
            }

            // Select the new object if it's not null
            if (newSelectable != null)
            {
                SelectNewObject(newSelectable);
                return true;
            }

            // Deselect if the new object is null
            if (selectableObject != null)
            {
                DeselectCurrentObject();
                selectableObject = null;
            }

            return false;
        }

        private void DeselectCurrentObject()
        {
            selectionResponse.OnDeselect(selectableObject);
        }

        private void SelectNewObject(GameObject newSelectable)
        {
            selectableObject = newSelectable;
            DebugPrint("Found Interactable " + interactable + " Interaction Object " + selectableObject);
            selectionResponse.OnSelect(selectableObject);
        }

        /// <summary>
        /// Check if an object contains a class implementing IInteractable
        /// </summary>
        /// <returns>true if object contains an Interact Method</returns>
        private GameObject CheckForSelectable()
        {
            DebugRay(transform.position, transform.forward * interactionDistance, Color.cyan);

            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, hitMask))
            {
                DebugRay(transform.position, transform.forward * interactionDistance, Color.red);

                GameObject selectedObject = hit.transform.gameObject;
                InteractionObject[] interactionObjects = selectedObject.GetComponents<InteractionObject>();
                interactable = null;
                foreach (var interactionObject in interactionObjects)
                {
                    interactable = interactionObject.Active ? interactionObject : null;
                }

                return interactable != null ? selectedObject : null;
            }

            interactable = null;
            return null;
        }

        #region Debugging

        private void DebugRay(Vector3 position, Vector3 dir, Color color)
        {
            if (debug)
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