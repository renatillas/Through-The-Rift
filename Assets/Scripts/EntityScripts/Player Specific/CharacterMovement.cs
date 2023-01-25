using UnityEngine;

namespace EntityScripts.Player_Specific
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    {
        private const float Gravity = -9.8f;

        [SerializeField] [Range(0, 10)] private float walkSpeed = 2f;
        [SerializeField] [Range(0, 10)] private float runSpeed = 2f;
        [SerializeField] [Range(500, 1500)] private float rotationSpeed = 1000;
        [SerializeField] private float runStaminaPerSec;
        private CharacterController _characterCtr;
        private bool _isStunned;
        private Vector3 _movementBuffer;

        private Stamina _stamina;

        private void Awake()
        {
            _stamina = GetComponent<Stamina>();
            _characterCtr = GetComponent<CharacterController>();
        }

        private void Start()
        {
            SetUnstunned();
        }

        private void LateUpdate()
        {
            Move();
        }

        public void BufferKnockBack(Vector3 velocity)
        {
            _movementBuffer = new Vector3(velocity.x, velocity.magnitude, velocity.z) * Time.deltaTime;
        }

        public void BufferWalk(Vector3 direction)
        {
            if (_isStunned) return;
            _movementBuffer = new Vector3(direction.x, 0, direction.z) * (walkSpeed * Time.deltaTime);
        }

        public void BufferRun(Vector3 direction)
        {
            if (_isStunned) return;
            if (!_stamina.UseStamina(runStaminaPerSec * Time.deltaTime))
            {
                BufferWalk(direction);
                return;
            }

            _movementBuffer = new Vector3(direction.x, 0, direction.z) * (runSpeed * Time.deltaTime);
        }

        private bool IsGrounded()
        {
            return _characterCtr.isGrounded;
        }

        private void Move()
        {
            // Ponemos una velocidad en y de -0.5 cuando esta en el suelo para que no flote.
            var fallMovement = IsGrounded() ? -0.5f : Gravity * Time.deltaTime;
            _movementBuffer.y = fallMovement;
            _characterCtr.Move(_movementBuffer);
            if (IsStunned()) return;
            RotateBody();
            _movementBuffer = Vector3.zero;
        }

        public bool IsStunned()
        {
            return _isStunned;
        }

        public void SetStunned()
        {
            _isStunned = true;
        }

        public void SetUnstunned()
        {
            _isStunned = false;
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