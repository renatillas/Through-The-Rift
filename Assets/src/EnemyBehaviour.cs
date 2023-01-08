using UnityEngine;

namespace src
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform transformChase;
        private MovementManager _movementManager;
        private float _playerHeight;

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

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                Attack();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Weapon"))
            {
                print("I was attacked!");
            }
        }

        private void RotateFacingPlayer()
        {
            var position = transformChase.position;
            transform.LookAt(new Vector3(position.x, _playerHeight, position.z));
        }

        private void Attack()
        {
            Debug.Log("Enemy attacked player!");
        }

        private Vector3 GetMoveDirection()
        {
            return (transformChase.position - transform.position).normalized;
        }
    }
}