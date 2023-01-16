using UnityEngine;

namespace EntityScripts
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private float runStamina;

        private Animator _animator;
        private CharacterMovement _characterMovement;
        private Stamina _stamina;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _animator = GetComponent<Animator>();
            _stamina = GetComponent<Stamina>();
        }

        private void Update()
        {
            if (IsMovementPressed())
            {
                if (IsRunningPressed() && _stamina.UseStamina(runStamina))
                {
                    _characterMovement.BufferRun(GetMovementDir());
                }
                else
                    _characterMovement.BufferWalk(GetMovementDir());
            }

            HandleAnimations();
        }

        void HandleAnimations()
        {
            bool isWalking = _animator.GetBool("isWalking");
            bool isRunning = _animator.GetBool("isRunning");

            if (IsMovementPressed() && !isWalking)
                _animator.SetBool("isWalking", true);
            else if (!IsMovementPressed() && isWalking)
                _animator.SetBool("isWalking", false);

            if (IsMovementPressed() && IsRunningPressed() && !isRunning && _stamina.HasStamina())
                _animator.SetBool("isRunning", true);
            else if ((!IsMovementPressed() || !IsRunningPressed()) && isRunning)
                _animator.SetBool("isRunning", false);
        }

        private static bool IsMovementPressed()
        {
            return GetMovementDir().magnitude >= 0;
        }

        private static bool IsRunningPressed()
        {
            return Input.GetButton("Run");
        }

        private static Vector3 GetMovementDir()
        {
            return new Vector3(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")).normalized;
        }
    }
}