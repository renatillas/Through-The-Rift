using UnityEngine;

namespace CharacterScripts
{
    [RequireComponent(typeof(CharacterMovement))]
    public class IAMovementController : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private Vector3 _playerPosition;
        private Stunnable _stunnable;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _playerPosition = GameObject.FindWithTag("Player").transform.position;
            _stunnable = GetComponent<Stunnable>();
        }

        private void FixedUpdate()
        {
            if (!_stunnable.IsStunned())
            {
                _characterMovement.Move(GetPlayerDirection());
            }
        }

        private Vector3 GetPlayerDirection()
        {
            Vector3 direction = (_playerPosition - transform.position).normalized;
            direction.y = 0f;
            return direction;
        }
    }
}