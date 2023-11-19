// GENERATED AUTOMATICALLY FROM 'Assets/_Wormcatcher/Scripts/FPS_Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FPS_Inputs"",
    ""maps"": [
        {
            ""name"": ""WalkInput"",
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
                },
                {
                    ""name"": ""SceneObject"",
                    ""type"": ""Button"",
                    ""id"": ""9706c5d8-a561-4bfd-ae35-0bd16124c34c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""664de548-ab24-4926-8ec6-2fe6d5de0d55"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""d0be347f-c9ce-4fa3-8b78-196337e0784b"",
                    ""expectedControlType"": ""Vector2"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""4e72f200-e4d9-4d93-b18f-a6a9e4a448b6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SceneObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b60740a2-3e19-4761-93bb-d80e1e7b3917"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3cf16b5-2186-4423-b4ea-c033fa23e998"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""StaticInput"",
            ""id"": ""3d33521b-0972-43f0-bbe8-d5240b0fde5c"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""fec2cf05-46ea-4d18-adfa-81be7e917451"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""45213cf0-d886-4d7c-9452-f285f4508c50"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // WalkInput
        m_WalkInput = asset.FindActionMap("WalkInput", throwIfNotFound: true);
        m_WalkInput_Movement = m_WalkInput.FindAction("Movement", throwIfNotFound: true);
        m_WalkInput_Sprint = m_WalkInput.FindAction("Sprint", throwIfNotFound: true);
        m_WalkInput_Interact = m_WalkInput.FindAction("Interact", throwIfNotFound: true);
        m_WalkInput_SceneObject = m_WalkInput.FindAction("SceneObject", throwIfNotFound: true);
        m_WalkInput_MouseLook = m_WalkInput.FindAction("MouseLook", throwIfNotFound: true);
        m_WalkInput_MousePosition = m_WalkInput.FindAction("MousePosition", throwIfNotFound: true);
        // StaticInput
        m_StaticInput = asset.FindActionMap("StaticInput", throwIfNotFound: true);
        m_StaticInput_Newaction = m_StaticInput.FindAction("New action", throwIfNotFound: true);
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

    // WalkInput
    private readonly InputActionMap m_WalkInput;
    private IWalkInputActions m_WalkInputActionsCallbackInterface;
    private readonly InputAction m_WalkInput_Movement;
    private readonly InputAction m_WalkInput_Sprint;
    private readonly InputAction m_WalkInput_Interact;
    private readonly InputAction m_WalkInput_SceneObject;
    private readonly InputAction m_WalkInput_MouseLook;
    private readonly InputAction m_WalkInput_MousePosition;
    public struct WalkInputActions
    {
        private @PlayerInputAction m_Wrapper;
        public WalkInputActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_WalkInput_Movement;
        public InputAction @Sprint => m_Wrapper.m_WalkInput_Sprint;
        public InputAction @Interact => m_Wrapper.m_WalkInput_Interact;
        public InputAction @SceneObject => m_Wrapper.m_WalkInput_SceneObject;
        public InputAction @MouseLook => m_Wrapper.m_WalkInput_MouseLook;
        public InputAction @MousePosition => m_Wrapper.m_WalkInput_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_WalkInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WalkInputActions set) { return set.Get(); }
        public void SetCallbacks(IWalkInputActions instance)
        {
            if (m_Wrapper.m_WalkInputActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnMovement;
                @Sprint.started -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnSprint;
                @Interact.started -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnInteract;
                @SceneObject.started -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnSceneObject;
                @SceneObject.performed -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnSceneObject;
                @SceneObject.canceled -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnSceneObject;
                @MouseLook.started -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnMouseLook;
                @MousePosition.started -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_WalkInputActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_WalkInputActionsCallbackInterface = instance;
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
                @SceneObject.started += instance.OnSceneObject;
                @SceneObject.performed += instance.OnSceneObject;
                @SceneObject.canceled += instance.OnSceneObject;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public WalkInputActions @WalkInput => new WalkInputActions(this);

    // StaticInput
    private readonly InputActionMap m_StaticInput;
    private IStaticInputActions m_StaticInputActionsCallbackInterface;
    private readonly InputAction m_StaticInput_Newaction;
    public struct StaticInputActions
    {
        private @PlayerInputAction m_Wrapper;
        public StaticInputActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_StaticInput_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_StaticInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StaticInputActions set) { return set.Get(); }
        public void SetCallbacks(IStaticInputActions instance)
        {
            if (m_Wrapper.m_StaticInputActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_StaticInputActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_StaticInputActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_StaticInputActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_StaticInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public StaticInputActions @StaticInput => new StaticInputActions(this);
    public interface IWalkInputActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSceneObject(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
    public interface IStaticInputActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
