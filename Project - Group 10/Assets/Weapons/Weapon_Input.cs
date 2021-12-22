// GENERATED AUTOMATICALLY FROM 'Assets/Weapons/Weapon_Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Weapon_Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Weapon_Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Weapon_Input"",
    ""maps"": [
        {
            ""name"": ""WeaponControl"",
            ""id"": ""c44faadc-d26b-403f-afaf-61f0a0f76862"",
            ""actions"": [
                {
                    ""name"": ""SlingLaunch"",
                    ""type"": ""Button"",
                    ""id"": ""e4516f4c-368d-41bb-9211-4de0116b2c68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a2f40703-ede4-4187-90c4-cd329a10f166"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlingLaunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // WeaponControl
        m_WeaponControl = asset.FindActionMap("WeaponControl", throwIfNotFound: true);
        m_WeaponControl_SlingLaunch = m_WeaponControl.FindAction("SlingLaunch", throwIfNotFound: true);
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

    // WeaponControl
    private readonly InputActionMap m_WeaponControl;
    private IWeaponControlActions m_WeaponControlActionsCallbackInterface;
    private readonly InputAction m_WeaponControl_SlingLaunch;
    public struct WeaponControlActions
    {
        private @Weapon_Input m_Wrapper;
        public WeaponControlActions(@Weapon_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @SlingLaunch => m_Wrapper.m_WeaponControl_SlingLaunch;
        public InputActionMap Get() { return m_Wrapper.m_WeaponControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponControlActions set) { return set.Get(); }
        public void SetCallbacks(IWeaponControlActions instance)
        {
            if (m_Wrapper.m_WeaponControlActionsCallbackInterface != null)
            {
                @SlingLaunch.started -= m_Wrapper.m_WeaponControlActionsCallbackInterface.OnSlingLaunch;
                @SlingLaunch.performed -= m_Wrapper.m_WeaponControlActionsCallbackInterface.OnSlingLaunch;
                @SlingLaunch.canceled -= m_Wrapper.m_WeaponControlActionsCallbackInterface.OnSlingLaunch;
            }
            m_Wrapper.m_WeaponControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SlingLaunch.started += instance.OnSlingLaunch;
                @SlingLaunch.performed += instance.OnSlingLaunch;
                @SlingLaunch.canceled += instance.OnSlingLaunch;
            }
        }
    }
    public WeaponControlActions @WeaponControl => new WeaponControlActions(this);
    public interface IWeaponControlActions
    {
        void OnSlingLaunch(InputAction.CallbackContext context);
    }
}
