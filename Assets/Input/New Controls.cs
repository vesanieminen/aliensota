// GENERATED AUTOMATICALLY FROM 'Assets/Input/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""19f6aa81-5212-4698-a13d-f017ce8cef48"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""ae9e3e8b-e0e2-405f-86ca-2430c4d5f2db"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7dc09d50-1b64-4c8b-8426-6bed2bec3ce5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Punch"",
                    ""type"": ""Button"",
                    ""id"": ""6795b132-da99-4332-9506-4d1920f35f98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Diggy"",
                    ""type"": ""Button"",
                    ""id"": ""6d615030-acaf-4401-a676-a33db8ac8a03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Diggy up"",
                    ""type"": ""Button"",
                    ""id"": ""66470132-91f1-41e5-abcf-5a809b603218"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""27bbb405-a800-4274-92e1-a2bae8b34d65"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11590e4e-4d37-4647-87b0-9eaef061ceb0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b81c8bd-99de-4499-b2a6-e86633f5b968"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da9b01d8-c7f3-4fcb-9635-6daf14af6cc7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Diggy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73525c8f-c53b-4cfa-af6a-a8ec6a1559e4"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Diggy up"",
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
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Punch = m_Player.FindAction("Punch", throwIfNotFound: true);
        m_Player_Diggy = m_Player.FindAction("Diggy", throwIfNotFound: true);
        m_Player_Diggyup = m_Player.FindAction("Diggy up", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Punch;
    private readonly InputAction m_Player_Diggy;
    private readonly InputAction m_Player_Diggyup;
    public struct PlayerActions
    {
        private @NewControls m_Wrapper;
        public PlayerActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Punch => m_Wrapper.m_Player_Punch;
        public InputAction @Diggy => m_Wrapper.m_Player_Diggy;
        public InputAction @Diggyup => m_Wrapper.m_Player_Diggyup;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Punch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunch;
                @Punch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunch;
                @Punch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunch;
                @Diggy.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDiggy;
                @Diggy.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDiggy;
                @Diggy.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDiggy;
                @Diggyup.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDiggyup;
                @Diggyup.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDiggyup;
                @Diggyup.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDiggyup;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Punch.started += instance.OnPunch;
                @Punch.performed += instance.OnPunch;
                @Punch.canceled += instance.OnPunch;
                @Diggy.started += instance.OnDiggy;
                @Diggy.performed += instance.OnDiggy;
                @Diggy.canceled += instance.OnDiggy;
                @Diggyup.started += instance.OnDiggyup;
                @Diggyup.performed += instance.OnDiggyup;
                @Diggyup.canceled += instance.OnDiggyup;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPunch(InputAction.CallbackContext context);
        void OnDiggy(InputAction.CallbackContext context);
        void OnDiggyup(InputAction.CallbackContext context);
    }
}
