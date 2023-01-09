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
        private float speed = 2f;

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

        public void Move(Vector3 direction)
        {
            var velocity = speed * direction;
            _rb.AddForce(velocity, ForceMode.VelocityChange);
            float yVelocity = _rb.velocity.y;
            Vector3 clampedVelocity = Vector3.ClampMagnitude(_rb.velocity, speed);
            _rb.velocity = new Vector3(clampedVelocity.x, yVelocity, clampedVelocity.z);
        }


        public bool TryJump()
        {
            if (!IsGrounded() || _hasJumpDelay) return false;
            BufferJump();
            return true;
        }

        private void BufferJump()
        {
            StartCoroutine(YieldJumpDelay());
            _animator.SetTrigger(JumpHash);
        }

        private void Jump(float jumpNewtons)
        {
            // Impulse (Imp or J) = F * t [Newton * Second]
            Vector3 force = (transform.up * jumpNewtons);
            Vector3 imp = force * Time.fixedDeltaTime;
            _rb.AddForce(imp, ForceMode.Impulse);
        }

        private IEnumerator YieldJumpDelay()
        {
            _hasJumpDelay = true;
            yield return new WaitForSeconds(jumpSecondsDelay);
            _hasJumpDelay = false;
        }

        public void OnJumpTakeOff()
        {
            Jump(jumpForceMagnitude);
        }
    }
}