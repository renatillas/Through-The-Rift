using UnityEngine;
using UnityEngine.InputSystem;

namespace EntityScripts
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerInputController : MonoBehaviour
    {
        private Animator _animator;
        private CharacterMovement _characterMovement;
        private Vector3 _currentMovement;

        private Vector2 _currentMovementInput;
        private bool _isMovementPressed;
        private bool _isRunPressed;

        private Input.Input _playerInput;

        private void Awake()
        {
            _playerInput = new Input.Input();
            _characterMovement = GetComponent<CharacterMovement>();
            _animator = GetComponent<Animator>();

            _playerInput.CharacterControls.Move.started += OnMovementInput;
            _playerInput.CharacterControls.Move.performed += OnMovementInput;
            _playerInput.CharacterControls.Move.canceled += OnMovementInput;
            _playerInput.CharacterControls.Run.started += OnRun;
            _playerInput.CharacterControls.Run.canceled += OnRun;
        }

        private void Update()
        {
            if (_isRunPressed) _characterMovement.BufferRun(_currentMovement);
            else if (_isMovementPressed) _characterMovement.BufferWalk(_currentMovement);
            HandleAnimation();
        }


        void OnEnable()
        {
            _playerInput.CharacterControls.Enable();
        }

        void OnDisable()
        {
            _playerInput.CharacterControls.Disable();
        }

        private void OnRun(InputAction.CallbackContext context)
        {
            _isRunPressed = context.ReadValueAsButton();
        }

        void OnMovementInput(InputAction.CallbackContext context)
        {
            _currentMovementInput = context.ReadValue<Vector2>();
            _currentMovement.x = _currentMovementInput.x;
            _currentMovement.z = _currentMovementInput.y;
            _isMovementPressed = _currentMovementInput.sqrMagnitude > 0;
        }

        void HandleAnimation()
        {
            _animator.SetBool("isWalking", _isMovementPressed && !_isRunPressed);
            _animator.SetBool("isRunning", _isRunPressed);
        }
    }
}