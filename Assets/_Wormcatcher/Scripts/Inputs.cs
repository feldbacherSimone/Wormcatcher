using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Wormcatcher.Scripts
{
    public class Inputs : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActionAsset;

        private InputAction interactAction;
        private InputAction sceneObjectAction;
        private InputAction movementAction;
        private InputAction sprintAction;

        private InputActionMap inputActionMap;
        public static Inputs Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            inputActionMap = inputActionAsset.FindActionMap("KeyboardMovement");
            interactAction = inputActionMap.FindAction("Interact");
            sceneObjectAction = inputActionMap.FindAction("SceneObject");

            sceneObjectAction.started += _ => SceneObjectHandler._instance.SpawnObject();
            sceneObjectAction.canceled += _ => SceneObjectHandler._instance.DespawnObject();
        }

        public InputAction getInput(string name)
        {
            return interactAction = inputActionMap.FindAction(name);
        }
    }
}