using UnityEngine;

namespace src
{
    public class EnemyManager : MonoBehaviour
    {
        private static readonly int DeathHash = Animator.StringToHash("Death");

        [Header("Stats")] [SerializeField] private int maxHealth;

        [SerializeField] private float attackDelay;
        private Animator _animator;
        private int _hp;

        private float _internalAttackTimer;
        private MovementManager _movementManager;

        private Transform _playerTransform;
        private Rigidbody _rb;
        private bool _stunt;
        private float _stuntTimer;

        private bool IsDead => _hp <= 0;

        private void Awake()
        {
            _movementManager = GetComponent<MovementManager>();
            _rb = GetComponent<Rigidbody>();
            _playerTransform = GameObject.FindWithTag("Player").transform;
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _hp = maxHealth;
        }

        private void Update()
        {
            Debug.DrawRay(transform.position, GetPlayerDirection(), Color.blue);

            _internalAttackTimer -= Time.deltaTime;

            if (_stuntTimer > 0) _stuntTimer -= Time.deltaTime;
            else UnapplyStun();
        }


        private void FixedUpdate()
        {
            if (_stunt || IsDead) return;
            _movementManager.Move(GetPlayerDirection());
            RotateFacingPlayer();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") &&
                _internalAttackTimer <= 0)
                BufferAttack();
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
            if (IsDead) KillEnemy();
        }

        private void KillEnemy()
        {
            ApplyStun();
            _animator.SetTrigger(DeathHash);
        }

        private void RotateFacingPlayer()
        {
            var position = _playerTransform.position;
            transform.LookAt(new Vector3(position.x, 0.0f, position.z));
        }

        private void BufferAttack()
        {
            _internalAttackTimer = attackDelay;
        }

        private Vector3 GetPlayerDirection()
        {
            Vector3 direction = (_playerTransform.position - transform.position).normalized;
            direction.y = 0f;
            return direction;
        }

        private void ApplyKnockback(Vector3 direction, float forceMagnitude)
        {
            ApplyStunForSeconds(0.5f);
            _rb.velocity = Vector3.zero;
            _rb.AddForceAtPosition(direction * forceMagnitude * Time.fixedDeltaTime,
                transform.position + Vector3.up * 1,
                ForceMode.Impulse);
        }

        public void ApplyKnockbackAwayFromPlayer(float forceMagnitude)
        {
            ApplyKnockback(-1 * GetPlayerDirection(), forceMagnitude);
        }

        void ApplyStun()
        {
            _stunt = true;
            _rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        private void UnapplyStun()
        {
            _stuntTimer = 0;
            _stunt = false;
            _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        void ApplyStunForSeconds(float seconds)
        {
            if (IsDead) return;
            ApplyStun();
            _stuntTimer = seconds;
        }
    }
}