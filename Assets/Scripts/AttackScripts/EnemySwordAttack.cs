using UnityEngine;

namespace AttackScripts
{
    public class EnemySwordAttack : MonoBehaviour, IWeaponAttack
    {
        [SerializeField] private float cooldownSeconds;

        private Animator _animator;
        private Coroutine _attackCoroutine;
        private bool _isAttacking;
        private float _timer;

        private void Awake()
        {
            _animator = GetComponentInParent<Animator>();
        }

        public void Start()
        {
            _timer = cooldownSeconds;
        }

        private void Update()
        {
            if (_timer > 0) _timer -= Time.deltaTime;
            else
            {
                if (_isAttacking) Attack();
                _timer = cooldownSeconds;
            }
        }

        public float Cooldown
        {
            get => cooldownSeconds;
            set => cooldownSeconds = value;
        }

        public void OnPlayerEntersAttackRange()
        {
            _isAttacking = true;
        }

        public void OnPlayerExitsAttackRange()
        {
            _isAttacking = false;
        }

        private void Attack()
        {
            _animator.SetTrigger("SwordAttack");
        }
    }
}