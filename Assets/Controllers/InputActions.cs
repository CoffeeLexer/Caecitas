//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Controllers/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""14f5a683-e639-4e8b-84c7-2df5e2f2f695"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""03f7cdc5-e2a1-4c2b-bc6a-f9b7af4c7af0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""5d8a0596-85c3-41f6-81a3-36e69aff4887"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""c081096e-3f38-48c0-a4fe-9d7838af5241"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""087ed9bd-94df-4871-afc0-e83744328105"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5e515bc5-9df5-4641-99ba-402d878e47cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5bbd00a7-5782-47c4-aeff-67d2a1fc7c61"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0c7ae61f-f3e8-4117-a1c3-5098db426e6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""328be4cf-9aaa-4c78-85bc-9ebe488653c2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""d1d71f7b-14d2-4504-b977-3b096517b143"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""14cb73a0-ebf8-4897-b522-82af4927a4d4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17162070-d285-4e17-82cd-9f63ccc15239"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19a516eb-f1a0-4c96-9ad4-2f02f3e1e6d1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74aa33d0-ae48-4484-b1b1-f1c15b622ad0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da927618-623e-44f7-9885-b1a61e4e0222"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""345c0acd-36d1-489a-9a2c-e64f0db3e7ea"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d003f5b-7ee4-4949-91d3-ff66bf41cac3"",
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
                    ""id"": ""eab8c058-d1c4-4110-a013-fe6a5e39412a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c50aedce-0cfe-42ef-a76c-be320d302ad9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b467c56d-6d02-460c-ac99-8a44f9c6c0fc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddd2ed15-a8b2-47a8-9aec-9cfdce786ade"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d395791-7d6d-457c-bab9-0eabfa63982b"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db89095e-1ff2-43a1-86e5-745f8701678b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Forward = m_Player.FindAction("Forward", throwIfNotFound: true);
        m_Player_Left = m_Player.FindAction("Left", throwIfNotFound: true);
        m_Player_Right = m_Player.FindAction("Right", throwIfNotFound: true);
        m_Player_Back = m_Player.FindAction("Back", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Scroll = m_Player.FindAction("Scroll", throwIfNotFound: true);
        m_Player_Throw = m_Player.FindAction("Throw", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Forward;
    private readonly InputAction m_Player_Left;
    private readonly InputAction m_Player_Right;
    private readonly InputAction m_Player_Back;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Scroll;
    private readonly InputAction m_Player_Throw;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Player_Forward;
        public InputAction @Left => m_Wrapper.m_Player_Left;
        public InputAction @Right => m_Wrapper.m_Player_Right;
        public InputAction @Back => m_Wrapper.m_Player_Back;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Scroll => m_Wrapper.m_Player_Scroll;
        public InputAction @Throw => m_Wrapper.m_Player_Throw;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Forward.started += instance.OnForward;
            @Forward.performed += instance.OnForward;
            @Forward.canceled += instance.OnForward;
            @Left.started += instance.OnLeft;
            @Left.performed += instance.OnLeft;
            @Left.canceled += instance.OnLeft;
            @Right.started += instance.OnRight;
            @Right.performed += instance.OnRight;
            @Right.canceled += instance.OnRight;
            @Back.started += instance.OnBack;
            @Back.performed += instance.OnBack;
            @Back.canceled += instance.OnBack;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Scroll.started += instance.OnScroll;
            @Scroll.performed += instance.OnScroll;
            @Scroll.canceled += instance.OnScroll;
            @Throw.started += instance.OnThrow;
            @Throw.performed += instance.OnThrow;
            @Throw.canceled += instance.OnThrow;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Forward.started -= instance.OnForward;
            @Forward.performed -= instance.OnForward;
            @Forward.canceled -= instance.OnForward;
            @Left.started -= instance.OnLeft;
            @Left.performed -= instance.OnLeft;
            @Left.canceled -= instance.OnLeft;
            @Right.started -= instance.OnRight;
            @Right.performed -= instance.OnRight;
            @Right.canceled -= instance.OnRight;
            @Back.started -= instance.OnBack;
            @Back.performed -= instance.OnBack;
            @Back.canceled -= instance.OnBack;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Scroll.started -= instance.OnScroll;
            @Scroll.performed -= instance.OnScroll;
            @Scroll.canceled -= instance.OnScroll;
            @Throw.started -= instance.OnThrow;
            @Throw.performed -= instance.OnThrow;
            @Throw.canceled -= instance.OnThrow;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
    }
}
