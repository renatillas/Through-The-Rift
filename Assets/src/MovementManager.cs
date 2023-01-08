using System.Collections;
using UnityEngine;

namespace src
{
    public class MovementManager : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float walkSpeed = 200f;
        [SerializeField] private float jumpDelay = 1f;
        [SerializeField] private float jumpForce;

        private bool _hasJumpDelay;
        private Rigidbody _rb;
        private Animator _animator;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Jump1 = Animator.StringToHash("Jump");

        private bool IsGrounded()
        {
            return Physics.CheckSphere(transform.position + Vector3.up * 0.1f, 0.2f);
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat(Speed, _rb.velocity.magnitude);
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
            Vector3 velocity = walkSpeed * direction;
            _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
        }


        public bool TryJump()
        {
            if (IsGrounded() && !_hasJumpDelay)
            {
                Jump(jumpForce);
                return true;
            }
            return false;
        }

        private void Jump(float inputJumpForce)
        {
            _rb.AddForce(transform.up * inputJumpForce, ForceMode.Impulse);
            _hasJumpDelay = true;
            _animator.SetTrigger(Jump1);
            StartCoroutine(YieldJumpDelay());
        }

        private IEnumerator YieldJumpDelay()
        {
            yield return new WaitForSeconds(jumpDelay);
            _hasJumpDelay = false;
        }
    }
}