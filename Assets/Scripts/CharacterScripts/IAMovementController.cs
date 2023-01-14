using UnityEngine;

namespace CharacterScripts
{
    [RequireComponent(typeof(CharacterMovement))]
    public class IAMovementController : MonoBehaviour
    {
        private bool _canMove;
        private CharacterMovement _characterMovement;
        private Transform _transformDestination;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _transformDestination = GameObject.FindWithTag("Player").transform;
        }

        private void Start()
        {
            _canMove = true;
        }


        private void FixedUpdate()
        {
            if (_canMove) _characterMovement.BufferWalk(GetPlayerDirection());
        }

        private Vector3 GetPlayerDirection()
        {
            Vector3 playerPosition = _transformDestination.position;
            Vector3 direction = (playerPosition - transform.position).normalized;
            direction.y = 0f;
            return direction;
        }

        public void StopMoving()
        {
            _canMove = false;
        }
    }
}