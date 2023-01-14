using UnityEngine;

namespace CharacterScripts
{
    [RequireComponent(typeof(CharacterMovement), typeof(Stunnable))]
    public class IAMovementController : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private Stunnable _stunnable;
        private Transform _transformDestination;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _stunnable = GetComponent<Stunnable>();
            _transformDestination = GameObject.FindWithTag("Player").transform;
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
            Vector3 playerPosition = _transformDestination.position;
            Vector3 direction = (playerPosition - transform.position).normalized;
            direction.y = 0f;
            return direction;
        }
    }
}