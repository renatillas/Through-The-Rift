using System.Collections;
using UnityEngine;

namespace AttackScripts
{
    public class EnemySwordAttack : MonoBehaviour, IWeaponAttack
    {
        [SerializeField] private float delay;

        private Animator _animator;
        private Coroutine _bufferAttackAnimationRoutine;
        private bool _isAttacking;

        private void Awake()
        {
            _animator = GetComponentInParent<Animator>();
        }

        public float WeaponCooldown
        {
            get => delay;
            set => delay = value;
        }

        public void PlayerOnSight()
        {
            if (_isAttacking) return;
            if (_bufferAttackAnimationRoutine == null)
                _bufferAttackAnimationRoutine = StartCoroutine(BufferAttackAnimation());
        }

        public void PlayerOutOfSight()
        {
            _isAttacking = false;
            if (_bufferAttackAnimationRoutine == null) return;
            StopCoroutine(_bufferAttackAnimationRoutine);
            _bufferAttackAnimationRoutine = null;
        }

        IEnumerator BufferAttackAnimation()
        {
            _isAttacking = true;
            while (_isAttacking)
            {
                _animator.SetTrigger("SwordAttack");
                yield return new WaitForSeconds(WeaponCooldown);
            }
        }
    }
}