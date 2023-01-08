using UnityEngine;

namespace src
{
    public class SwordManager : MonoBehaviour
    {
        // Necesarios para las animaciones
        private static readonly int SwordAttack = Animator.StringToHash("SwordAttack");
        private static readonly int AnimationSpeedHash = Animator.StringToHash("SwordAttackAnimationSpeed");

        [Header("Weapon stats")] [SerializeField, Range(0, 100)]
        private int damage;

        [SerializeField, Min(0)] private float delay;
        [SerializeField, Min(0)] private float knockbackMagnitude;

        [Space] [SerializeField] private Animator animator;

        private float _internalTimer;
        private ParticleSystem _particleSystem;
        private Collider _swordTriggerCollider;

        private void Awake()
        {
            _swordTriggerCollider = GetComponent<BoxCollider>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();
        }

        private void Start()
        {
            _internalTimer = 0;
            _particleSystem.Stop();
        }

        private void Update()
        {
            var animationSpeed = 2 / delay;
            animator.SetFloat(AnimationSpeedHash, animationSpeed);

            _internalTimer -= Time.deltaTime;
            if (_internalTimer < 0f)
            {
                StartAttack();
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;

            var enemy = other.gameObject.GetComponent<EnemyManager>();
            enemy.TakeDamage(damage);
            enemy.ApplyPlayerKnockback(knockbackMagnitude);
        }

        public void StartAttack()
        {
            _internalTimer = delay;
            animator.SetTrigger(SwordAttack);
            _particleSystem.Play();
        }

        public void StartAttackWind()
        {
            _swordTriggerCollider.enabled = true;
        }

        public void EndAttackWind()
        {
            _swordTriggerCollider.enabled = false;
            _particleSystem.Stop();
        }
    }
}