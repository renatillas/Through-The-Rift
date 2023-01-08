using UnityEngine;

namespace src
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private Transform playerTransform;
        private int _hp;

        private MovementManager _movementManager;
        private Rigidbody _rb;

        private void Awake()
        {
            _movementManager = GetComponent<MovementManager>();
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _hp = maxHealth;
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

        public void TakeDamage(int damage)
        {
            _hp -= damage;
            if (_hp < 1)
                Destroy(gameObject);
        }

        private void RotateFacingPlayer()
        {
            var position = playerTransform.position;
            transform.LookAt(new Vector3(position.x, 0.0f, position.z));
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