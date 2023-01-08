using System.Collections;
using UnityEngine;

namespace src
{
    public class MovementManager : MonoBehaviour
    {
        // Necesarios para optimizar el motor de animaciones.
        private static readonly int SpeedHash = Animator.StringToHash("Speed");
        private static readonly int JumpHash = Animator.StringToHash("Jump");

        [Header("Walk settings")] [SerializeField, Range(0, 10)]
        private float speed = 200f;

        [Header("Jump settings")] [SerializeField]
        private float jumpSecondsDelay = 1f;

        [SerializeField] private float jumpForceMagnitude;

        private Animator _animator;
        private bool _hasJumpDelay;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat(SpeedHash, _rb.velocity.magnitude);
        }

        private bool IsGrounded()
        {
            return Physics.CheckSphere(transform.position + Vector3.up * 0.1f, 0.2f);
        }

        public bool TryMove(Vector3 direction)
        {
            if (IsGrounded())

            {
                Move(direction);
                return true;
            }

            return false;
        }

        private void Move(Vector3 direction)
        {
            var velocity = speed * direction;
            _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
        }


        public bool TryJump()
        {
            if (!IsGrounded() || _hasJumpDelay) return false;
            Jump(jumpForceMagnitude);
            return true;
        }

        private void Jump(float inputMagnitude)
        {
            _rb.AddForce(transform.up * inputMagnitude, ForceMode.Impulse);
            _hasJumpDelay = true;
            _animator.SetTrigger(JumpHash);
            StartCoroutine(YieldJumpDelay());
        }

        private IEnumerator YieldJumpDelay()
        {
            yield return new WaitForSeconds(jumpSecondsDelay);
            _hasJumpDelay = false;
        }
    }
}