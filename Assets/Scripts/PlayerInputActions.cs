// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""OnGround"",
            ""id"": ""a6e0faab-1661-4f0e-b96e-dabd0a2bd7fc"",
            ""actions"": [
                {
                    ""name"": ""Ride"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bc9ec5b1-116f-44c6-acec-fbd251acfedb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press,Hold""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""998b7b12-7059-437e-83f8-8f169ec71c69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""54f98111-6d03-4868-8c1e-70a41db40dc6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ride"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""89be6b03-2e65-4f45-a373-05e37d8492f5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ride"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fe3af3a3-9f83-4b5c-bacf-6f6c9996cd07"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ride"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // OnGround
        m_OnGround = asset.FindActionMap("OnGround", throwIfNotFound: true);
        m_OnGround_Ride = m_OnGround.FindAction("Ride", throwIfNotFound: true);
        m_OnGround_Jump = m_OnGround.FindAction("Jump", throwIfNotFound: true);
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

    // OnGround
    private readonly InputActionMap m_OnGround;
    private IOnGroundActions m_OnGroundActionsCallbackInterface;
    private readonly InputAction m_OnGround_Ride;
    private readonly InputAction m_OnGround_Jump;
    public struct OnGroundActions
    {
        private @PlayerInputActions m_Wrapper;
        public OnGroundActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ride => m_Wrapper.m_OnGround_Ride;
        public InputAction @Jump => m_Wrapper.m_OnGround_Jump;
        public InputActionMap Get() { return m_Wrapper.m_OnGround; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OnGroundActions set) { return set.Get(); }
        public void SetCallbacks(IOnGroundActions instance)
        {
            if (m_Wrapper.m_OnGroundActionsCallbackInterface != null)
            {
                @Ride.started -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnRide;
                @Ride.performed -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnRide;
                @Ride.canceled -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnRide;
                @Jump.started -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_OnGroundActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Ride.started += instance.OnRide;
                @Ride.performed += instance.OnRide;
                @Ride.canceled += instance.OnRide;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public OnGroundActions @OnGround => new OnGroundActions(this);
    public interface IOnGroundActions
    {
        void OnRide(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
