// GENERATED AUTOMATICALLY FROM 'Assets/_Wormcatcher/Scripts/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""KeyboardMovement"",
            ""id"": ""18435f05-f574-4280-9139-e9bee0b28cd8"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""2c9b27ce-f5a4-48ff-a3b5-e1727436e092"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""8af11688-173c-409b-abe5-d1931754f8cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cebdd36c-eebd-49b5-b320-e823ccc3688c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""94b7ae49-18a7-4393-85f4-ab5fcdc939ff"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""87c9c085-8b29-474d-8af8-565924bdd9a4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""82cced94-89be-481f-8be6-ea45390bff38"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""69faa527-6454-4118-8983-3dc0c8aa1cfa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b37990a4-9cfe-42ff-8bde-0b301d3695de"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeyboardMovement
        m_KeyboardMovement = asset.FindActionMap("KeyboardMovement", throwIfNotFound: true);
        m_KeyboardMovement_Movement = m_KeyboardMovement.FindAction("Movement", throwIfNotFound: true);
        m_KeyboardMovement_Sprint = m_KeyboardMovement.FindAction("Sprint", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // KeyboardMovement
    private readonly InputActionMap m_KeyboardMovement;
    private IKeyboardMovementActions m_KeyboardMovementActionsCallbackInterface;
    private readonly InputAction m_KeyboardMovement_Movement;
    private readonly InputAction m_KeyboardMovement_Sprint;
    public struct KeyboardMovementActions
    {
        private @PlayerInputs m_Wrapper;
        public KeyboardMovementActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_KeyboardMovement_Movement;
        public InputAction @Sprint => m_Wrapper.m_KeyboardMovement_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardMovementActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardMovementActions instance)
        {
            if (m_Wrapper.m_KeyboardMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_KeyboardMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_KeyboardMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_KeyboardMovementActionsCallbackInterface.OnMovement;
                @Sprint.started -= m_Wrapper.m_KeyboardMovementActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_KeyboardMovementActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_KeyboardMovementActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_KeyboardMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
            }
        }
    }
    public KeyboardMovementActions @KeyboardMovement => new KeyboardMovementActions(this);
    public interface IKeyboardMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
}
