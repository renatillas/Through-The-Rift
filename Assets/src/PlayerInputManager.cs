using UnityEngine;

namespace src
{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private Transform body;
        [SerializeField] private float rotationSpeed;

        private MovementManager _movementManager;

        private void Awake()
        {
            _movementManager = GetComponent<MovementManager>();
        }

        private void Update()
        {
            RotateBody();
        }

        private void FixedUpdate()
        {
            if (Input.GetAxis("Jump") > 0)
                _movementManager.TryJump();

            if (GetMoveDirection().sqrMagnitude > 0)
                _movementManager.Move(GetMoveDirection());
        }

        private Vector3 GetMoveDirection()
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }

        private void RotateBody()
        {
            var direction = GetMoveDirection();
            if (direction.sqrMagnitude >= 0.1)
                body.rotation = Quaternion.Slerp(body.rotation, Quaternion.LookRotation(direction),
                    rotationSpeed * Time.deltaTime);
        }
    }
}