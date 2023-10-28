using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;

    [SerializeField] private float interactionDistance = 10f;

    [SerializeField] private Boolean debug; 
    private RaycastHit hit;
    private GameObject selectableGameObject;
    private void Awake()
    {
        
    }

    private void Update()
    {
        CheckForSelectable();
        if (selectableGameObject != null)
        {
            //TODO Highlight Object
            //TODO check if interaction button is pressed 
                //TODO call interaction in object 
        }
    }

    private void CheckForSelectable()
    {
        DebugRay(transform.position, transform.forward * interactionDistance, Color.cyan);
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            DebugRay(transform.position, transform.forward * interactionDistance, Color.red);
            //TODO check if object has interactable script 
            //TODO Return object 
        }
    }

    private void DebugRay(Vector3 position, Vector3 dir, Color color)
    {
        if(debug)
            Debug.DrawRay(position, dir, color);
    }
    
}
