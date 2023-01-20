// GENERATED AUTOMATICALLY FROM 'Assets/Animations/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Input
{
    public class @Input : IInputActionCollection, IDisposable
    {
        // CharacterControls
        private readonly InputActionMap m_CharacterControls;
        private readonly InputAction m_CharacterControls_Move;
        private readonly InputAction m_CharacterControls_Run;
        private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;

        public @Input()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""fbbadc6f-41f7-4971-9a84-704f7e07cdc5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""175d5177-f413-4f24-9946-64cd8e89ede5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""9ffa841f-5107-499b-a636-76f762ee943f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""da803c97-c2d8-4316-9ab7-ced9d720cd9b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9de6b35c-d4f0-4c2f-a50d-c08b320756dc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ad2be3ba-d713-4916-908f-bcb34030ba7e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9efacdf1-75fe-41ee-bc85-ff76adf07f02"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d2132614-2149-4c58-879f-a4c604993dc5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""75a8ab3d-fa0c-45b5-bc7f-32b60d7e47ea"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // CharacterControls
            m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
            m_CharacterControls_Move = m_CharacterControls.FindAction("Move", throwIfNotFound: true);
            m_CharacterControls_Run = m_CharacterControls.FindAction("Run", throwIfNotFound: true);
        }

        public InputActionAsset asset { get; }
        public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);

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

        public struct CharacterControlsActions
        {
            private @Input m_Wrapper;

            public CharacterControlsActions(@Input wrapper)
            {
                m_Wrapper = wrapper;
            }

            public InputAction @Move => m_Wrapper.m_CharacterControls_Move;
            public InputAction @Run => m_Wrapper.m_CharacterControls_Run;

            public InputActionMap Get()
            {
                return m_Wrapper.m_CharacterControls;
            }

            public void Enable()
            {
                Get().Enable();
            }

            public void Disable()
            {
                Get().Disable();
            }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(CharacterControlsActions set)
            {
                return set.Get();
            }

            public void SetCallbacks(ICharacterControlsActions instance)
            {
                if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                    @Run.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                    @Run.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                    @Run.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                }

                m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Run.started += instance.OnRun;
                    @Run.performed += instance.OnRun;
                    @Run.canceled += instance.OnRun;
                }
            }
        }

        public interface ICharacterControlsActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
        }
    }
}