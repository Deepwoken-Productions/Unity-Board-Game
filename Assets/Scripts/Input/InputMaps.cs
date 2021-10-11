// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputMaps.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaps : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaps()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaps"",
    ""maps"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""id"": ""2a5ccc3f-a4a0-40e0-85a1-812d636680b7"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""c32823ab-d25f-4c8f-b958-26ff61b4eaaa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9391c588-03f3-4319-8a71-47216c3e156b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""9000ebdf-9ae6-4343-9ad3-48d617116054"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlipCard"",
                    ""type"": ""Button"",
                    ""id"": ""97182d80-79ed-426e-b41f-4c1815a4d27e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""21be2607-a076-44b2-8b89-b49f4f04c134"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC master race"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c023133c-13de-4014-a072-3328e89d7804"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC master race"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b0878ac-2d87-4aea-89ed-5c791dcef3d1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC master race"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f56d5ff8-dd80-4e53-8fc2-b2e04c005816"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC master race"",
                    ""action"": ""FlipCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC master race"",
            ""bindingGroup"": ""PC master race"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // KeyboardAndMouse
        m_KeyboardAndMouse = asset.FindActionMap("KeyboardAndMouse", throwIfNotFound: true);
        m_KeyboardAndMouse_Click = m_KeyboardAndMouse.FindAction("Click", throwIfNotFound: true);
        m_KeyboardAndMouse_MousePosition = m_KeyboardAndMouse.FindAction("MousePosition", throwIfNotFound: true);
        m_KeyboardAndMouse_RightClick = m_KeyboardAndMouse.FindAction("RightClick", throwIfNotFound: true);
        m_KeyboardAndMouse_FlipCard = m_KeyboardAndMouse.FindAction("FlipCard", throwIfNotFound: true);
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

    // KeyboardAndMouse
    private readonly InputActionMap m_KeyboardAndMouse;
    private IKeyboardAndMouseActions m_KeyboardAndMouseActionsCallbackInterface;
    private readonly InputAction m_KeyboardAndMouse_Click;
    private readonly InputAction m_KeyboardAndMouse_MousePosition;
    private readonly InputAction m_KeyboardAndMouse_RightClick;
    private readonly InputAction m_KeyboardAndMouse_FlipCard;
    public struct KeyboardAndMouseActions
    {
        private @InputMaps m_Wrapper;
        public KeyboardAndMouseActions(@InputMaps wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_KeyboardAndMouse_Click;
        public InputAction @MousePosition => m_Wrapper.m_KeyboardAndMouse_MousePosition;
        public InputAction @RightClick => m_Wrapper.m_KeyboardAndMouse_RightClick;
        public InputAction @FlipCard => m_Wrapper.m_KeyboardAndMouse_FlipCard;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardAndMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardAndMouseActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardAndMouseActions instance)
        {
            if (m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnClick;
                @MousePosition.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnMousePosition;
                @RightClick.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRightClick;
                @FlipCard.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnFlipCard;
                @FlipCard.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnFlipCard;
                @FlipCard.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnFlipCard;
            }
            m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @FlipCard.started += instance.OnFlipCard;
                @FlipCard.performed += instance.OnFlipCard;
                @FlipCard.canceled += instance.OnFlipCard;
            }
        }
    }
    public KeyboardAndMouseActions @KeyboardAndMouse => new KeyboardAndMouseActions(this);
    private int m_PCmasterraceSchemeIndex = -1;
    public InputControlScheme PCmasterraceScheme
    {
        get
        {
            if (m_PCmasterraceSchemeIndex == -1) m_PCmasterraceSchemeIndex = asset.FindControlSchemeIndex("PC master race");
            return asset.controlSchemes[m_PCmasterraceSchemeIndex];
        }
    }
    public interface IKeyboardAndMouseActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnFlipCard(InputAction.CallbackContext context);
    }
}
