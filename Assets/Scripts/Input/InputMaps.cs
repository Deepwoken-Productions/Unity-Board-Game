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
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""eab9d625-1ad0-4034-add0-1c9c7fb6ccca"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Yes"",
                    ""type"": ""Button"",
                    ""id"": ""441969d7-1faa-43ec-8940-48eadc8deb1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""No"",
                    ""type"": ""Button"",
                    ""id"": ""aea83a04-568f-45ab-b3d0-b6e0dbc0f69c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
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
                },
                {
                    ""name"": """",
                    ""id"": ""fdaf02c9-29ee-4d3f-9f61-e6664e5d583e"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC master race"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c833c663-9bcf-4590-84fc-2ea1f916b62c"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57587231-95c2-42ce-80e6-11e9e65ecbb9"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""No"",
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
        m_KeyboardAndMouse_Zoom = m_KeyboardAndMouse.FindAction("Zoom", throwIfNotFound: true);
        m_KeyboardAndMouse_Yes = m_KeyboardAndMouse.FindAction("Yes", throwIfNotFound: true);
        m_KeyboardAndMouse_No = m_KeyboardAndMouse.FindAction("No", throwIfNotFound: true);
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
    private readonly InputAction m_KeyboardAndMouse_Zoom;
    private readonly InputAction m_KeyboardAndMouse_Yes;
    private readonly InputAction m_KeyboardAndMouse_No;
    public struct KeyboardAndMouseActions
    {
        private @InputMaps m_Wrapper;
        public KeyboardAndMouseActions(@InputMaps wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_KeyboardAndMouse_Click;
        public InputAction @MousePosition => m_Wrapper.m_KeyboardAndMouse_MousePosition;
        public InputAction @RightClick => m_Wrapper.m_KeyboardAndMouse_RightClick;
        public InputAction @FlipCard => m_Wrapper.m_KeyboardAndMouse_FlipCard;
        public InputAction @Zoom => m_Wrapper.m_KeyboardAndMouse_Zoom;
        public InputAction @Yes => m_Wrapper.m_KeyboardAndMouse_Yes;
        public InputAction @No => m_Wrapper.m_KeyboardAndMouse_No;
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
                @Zoom.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnZoom;
                @Yes.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnYes;
                @Yes.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnYes;
                @Yes.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnYes;
                @No.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnNo;
                @No.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnNo;
                @No.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnNo;
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
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Yes.started += instance.OnYes;
                @Yes.performed += instance.OnYes;
                @Yes.canceled += instance.OnYes;
                @No.started += instance.OnNo;
                @No.performed += instance.OnNo;
                @No.canceled += instance.OnNo;
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
        void OnZoom(InputAction.CallbackContext context);
        void OnYes(InputAction.CallbackContext context);
        void OnNo(InputAction.CallbackContext context);
    }
}
