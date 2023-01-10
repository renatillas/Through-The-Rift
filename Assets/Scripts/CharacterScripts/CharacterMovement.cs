using UnityEngine;

namespace CharacterScripts
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] [Range(0, 10)] private float speed = 2f;
        [SerializeField] [Range(500, 1500)] private float rotationSpeed = 1000;
        private Animator _animator;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat("Speed", _rb.velocity.magnitude);
        }

        public void Move(Vector3 direction)
        {
            var velocity = speed * direction;
            _rb.AddForce(velocity, ForceMode.VelocityChange);
            float yVelocity = _rb.velocity.y;
            Vector3 clampedVelocity = Vector3.ClampMagnitude(_rb.velocity, speed);
            _rb.velocity = new Vector3(clampedVelocity.x, yVelocity, clampedVelocity.z);
            RotateBody(direction);
        }

        private void RotateBody(Vector3 direction)
        {
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(direction),
                    rotationSpeed * Time.fixedDeltaTime);
        }
    }
}