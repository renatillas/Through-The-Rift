using System.Collections.Generic;
using UnityEngine;

namespace src.WeaponScripts
{
    public class SwordManager : MonoBehaviour
    {
        // Necesarios para las animaciones
        private static readonly int SwordAttack = Animator.StringToHash("SwordAttack");
        private static readonly int AnimationSpeedHash = Animator.StringToHash("SwordAttackAnimationSpeed");

        [Header("Weapon stats")] [SerializeField, Range(0, 100)]
        private int damage;

        [SerializeField, Range(0, 10)] private float delay;
        [SerializeField, Min(0)] private float knockbackForceMagnitude;
        private Animator _animator;
        private int _currentAttackId;


        private Dictionary<GameObject, int> _enemyLastAttacks;
        private float _internalTimer;
        private ParticleSystem _particleSystem;
        private Collider _swordTriggerCollider;

        private void Awake()
        {
            _swordTriggerCollider = GetComponent<BoxCollider>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();
            _animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        }

        private void Start()
        {
            _enemyLastAttacks = new Dictionary<GameObject, int>();
            _internalTimer = 0;
            _particleSystem.Stop();
        }

        private void Update()
        {
            var animationSpeed = 1 / delay;
            _animator.SetFloat(AnimationSpeedHash, animationSpeed);

            _internalTimer -= Time.deltaTime;
            if (_internalTimer < 0f) BufferAttack();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;

            GameObject enemy = other.gameObject;

            if (HasEnemyAlreadyBeenAttacked(enemy)) return;

            SendAttackToEnemy(enemy);
        }

        private bool HasEnemyAlreadyBeenAttacked(GameObject enemy)
        {
            if (_enemyLastAttacks.TryGetValue(enemy, out int lastAttackId) && lastAttackId.Equals(_currentAttackId))
                return true;
            _enemyLastAttacks[enemy] = _currentAttackId;
            return false;
        }

        private void SendAttackToEnemy(GameObject enemy)
        {
            EnemyManager enemyManager = enemy.GetComponent<EnemyManager>();
            enemyManager.TakeDamage(damage);
            enemyManager.ApplyKnockbackAwayFromPlayer(knockbackForceMagnitude);
        }

        private void BufferAttack()
        {
            _currentAttackId = Time.time.GetHashCode();
            _internalTimer = delay;
            _animator.SetTrigger(SwordAttack);
            _particleSystem.Play();
        }

        public void OnAttackWind()
        {
            _swordTriggerCollider.enabled = true;
        }

        public void OnEndAttackWind()
        {
            _swordTriggerCollider.enabled = false;
            _particleSystem.Stop();
        }
    }
}