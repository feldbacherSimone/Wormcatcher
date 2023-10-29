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
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""eaaa0b2a-551c-478a-a0a4-6bd5793eb9c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cebdd36c-eebd-49b5-b320-e823ccc3688c"",
                    ""path"": ""2DVector(mode=2)"",
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
                    ""id"": ""f052ae4f-14c3-4cef-b9cd-aeb4ff54aae7"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                },
                {
                    ""name"": """",
                    ""id"": ""c2d20ef6-d1f3-4e95-bb13-72a1613b0e86"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b56b18b-6e8e-48f8-8521-c117270313e5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ControllerMovement"",
            ""id"": ""b16d0a8e-595e-4fd8-bc96-58f1efa16372"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0bce1a40-f454-4b40-89a2-e643a514fe83"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""69e0926b-20f9-4b12-b2a8-f231390afa66"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
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
        m_KeyboardMovement_Interact = m_KeyboardMovement.FindAction("Interact", throwIfNotFound: true);
        // ControllerMovement
        m_ControllerMovement = asset.FindActionMap("ControllerMovement", throwIfNotFound: true);
        m_ControllerMovement_Movement = m_ControllerMovement.FindAction("Movement", throwIfNotFound: true);
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
    private readonly InputAction m_KeyboardMovement_Interact;
    public struct KeyboardMovementActions
    {
        private @PlayerInputs m_Wrapper;
        public KeyboardMovementActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_KeyboardMovement_Movement;
        public InputAction @Sprint => m_Wrapper.m_KeyboardMovement_Sprint;
        public InputAction @Interact => m_Wrapper.m_KeyboardMovement_Interact;
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
                @Interact.started -= m_Wrapper.m_KeyboardMovementActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_KeyboardMovementActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_KeyboardMovementActionsCallbackInterface.OnInteract;
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
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public KeyboardMovementActions @KeyboardMovement => new KeyboardMovementActions(this);

    // ControllerMovement
    private readonly InputActionMap m_ControllerMovement;
    private IControllerMovementActions m_ControllerMovementActionsCallbackInterface;
    private readonly InputAction m_ControllerMovement_Movement;
    public struct ControllerMovementActions
    {
        private @PlayerInputs m_Wrapper;
        public ControllerMovementActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_ControllerMovement_Movement;
        public InputActionMap Get() { return m_Wrapper.m_ControllerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IControllerMovementActions instance)
        {
            if (m_Wrapper.m_ControllerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ControllerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ControllerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ControllerMovementActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_ControllerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public ControllerMovementActions @ControllerMovement => new ControllerMovementActions(this);
    public interface IKeyboardMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IControllerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}
