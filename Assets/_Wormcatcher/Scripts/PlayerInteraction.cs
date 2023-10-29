using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = System.Object;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    private InputAction interactAction;

    [SerializeField] private float interactionDistance = 10f;

    [SerializeField] private Boolean debug; 
    private RaycastHit hit;
    private IInteractable interactable;
    private void Awake()
    {
        InputActionMap inputActionMap = inputActionAsset.FindActionMap("KeyboardMovement");
        interactAction = inputActionMap.FindAction("Interact");
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
            DebugPrint("Found Interactable " + interactable);
            //TODO Highlight Object
            if(interactAction.triggered)
                interactable.Interact(); DebugPrint("interaction Triggered");
        }
    }

    private void CheckForSelectable()
    {
        DebugRay(transform.position, transform.forward * interactionDistance, Color.cyan);
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            DebugRay(transform.position, transform.forward * interactionDistance, Color.red);
            interactable = hit.transform.GetComponent<IInteractable>();
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
