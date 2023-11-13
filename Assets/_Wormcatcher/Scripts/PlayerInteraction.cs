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
        private InputAction sceneObjectAction;

        [SerializeField] private float interactionDistance = 10f;

        [SerializeField] private Boolean debug;
        private RaycastHit hit;
        private IInteractable interactable;

        private GameObject selectableObject;


        private void Awake()
        {
            var inputActionMap = inputActionAsset.FindActionMap("KeyboardMovement");
            interactAction = inputActionMap.FindAction("Interact");
            sceneObjectAction = inputActionMap.FindAction("SceneObject");
            selectionResponse = selectionResponseObject.GetComponent<ISelectableObject>();

            sceneObjectAction.started += _ => SceneObjectHandler._instance.SpawnObject();
            sceneObjectAction.canceled += _ => SceneObjectHandler._instance.DespawnObject();
        }

        private void OnEnable()
        {
            interactAction.Enable();
            sceneObjectAction.Enable();
        }

        private void Update()
        {
            if (ValidObjectSelection() && interactAction.triggered)
            {
                interactable.Interact();
                DebugPrint("interaction Triggered");
            }
            
        }

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
            Debug.Log("Found Interactable " + interactable + " Interaction Object " + selectableObject);
            selectionResponse.OnSelect(selectableObject);
        }

        private GameObject CheckForSelectable()
        {
            DebugRay(transform.position, transform.forward * interactionDistance, Color.cyan);

            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
            {
                DebugRay(transform.position, transform.forward * interactionDistance, Color.red);

                GameObject selectedObject = hit.transform.gameObject;
                interactable = selectedObject.TryGetComponent(out interactable) ? interactable : null;

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