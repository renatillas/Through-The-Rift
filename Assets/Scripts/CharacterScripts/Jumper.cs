using UnityEngine;
using UnityEngine.Serialization;

namespace CharacterScripts
{
    public class Jumper : MonoBehaviour
    {
        [FormerlySerializedAs("jumpImpulse")] [SerializeField]
        private float jumpNewtons;

        [SerializeField] private float jumpCooldown;
        private Animator _animator;

        private Rigidbody _rb;

        private float _timeSinceLastJump;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _timeSinceLastJump = jumpCooldown;
        }

        private void Update()
        {
            _timeSinceLastJump += Time.deltaTime;
        }

        public void TryJump()
        {
            if (IsGrounded() && !IsJumpInCooldown()) BufferAnimationJump();
        }

        private void BufferAnimationJump()
        {
            _timeSinceLastJump = 0f;
            _animator.SetTrigger("Jump");
        }

        public void Jump()
        {
            // Impulse (Imp or J) = F * t [Newton * Second]
            Vector3 force = (transform.up * jumpNewtons);
            Vector3 imp = force * Time.fixedDeltaTime;
            _rb.AddForce(imp, ForceMode.Impulse);
        }

        private bool IsGrounded()
        {
            return Physics.CheckSphere(transform.position + Vector3.up * 0.1f, 0.2f);
        }

        private bool IsJumpInCooldown()
        {
            return _timeSinceLastJump < jumpCooldown;
        }
    }
}