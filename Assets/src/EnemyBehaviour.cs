using UnityEngine;
using UnityEngine.Serialization;

namespace src
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [FormerlySerializedAs("playerLocation")] [SerializeField] private Transform playerTransform;

        private float _playerHeight;
        private MovementManager _movementManager;

        private void Awake()
        {
            _movementManager = GetComponent<MovementManager>();
        }

        private void Update()
        {
            _playerHeight = transform.position.y;
        }

        private void FixedUpdate()
        {
            _movementManager.TryMove(GetMoveDirection());
            RotateFacingPlayer();
        }

        private void RotateFacingPlayer()
        {
            var position = playerTransform.position;
            transform.LookAt(new Vector3(position.x, _playerHeight, position.z));
        }

        private void Attack()
        {
            Debug.Log("Enemy attacked player!");
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                Attack();
        }

        private Vector3 GetMoveDirection()
        {
            return (playerTransform.position - transform.position).normalized;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Weapon"))
            {
                print("I was attacked!");
            }
        }
    }
}