using UnityEngine;

namespace CharacterScripts
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    {
        private const float Gravity = -9.8f;
        [SerializeField] [Range(0, 10)] private float walkSpeed = 2f;
        [SerializeField] [Range(0, 10)] private float runSpeed = 2f;
        [SerializeField] [Range(500, 1500)] private float rotationSpeed = 1000;
        private CharacterController _characterCtr;

        private Vector3 _movementBuffer;

        private void Awake()
        {
            _characterCtr = GetComponent<CharacterController>();
        }

        private void LateUpdate()
        {
            Move();
        }

        public void BufferKnockBack(Vector3 velocity)
        {
            _movementBuffer = new Vector3(velocity.x, 0f, velocity.z);
        }

        public Vector3 GetBodyCenter()
        {
            return _characterCtr.center;
        }

        public void BufferWalk(Vector3 direction)
        {
            _movementBuffer = new Vector3(direction.x, 0, direction.z) * (walkSpeed * Time.deltaTime);
        }

        public void BufferRun(Vector3 direction)
        {
            _movementBuffer = new Vector3(direction.x, 0, direction.z) * (runSpeed * Time.deltaTime);
        }

        private bool IsGrounded()
        {
            return _characterCtr.isGrounded;
        }

        private void Move()
        {
            RotateBody();

            if (IsGrounded()) _movementBuffer.y = -.5f;
            else _movementBuffer.y = Gravity * Time.deltaTime;
            _characterCtr.Move(_movementBuffer);
            _movementBuffer = Vector3.zero;
        }

        private void RotateBody()
        {
            if (_movementBuffer.x != 0 || _movementBuffer.z != 0)
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(new Vector3(_movementBuffer.x, 0, _movementBuffer.z)),
                    rotationSpeed * Time.fixedDeltaTime);
        }
    }
}