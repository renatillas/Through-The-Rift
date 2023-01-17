using System.Collections;
using UnityEngine;

namespace AttackScripts
{
    public class EnemySwordAttack : MonoBehaviour, IWeaponAttack
    {
        [SerializeField] private float delay;

        private Animator _animator;
        private Coroutine _bufferAttackAnimationRoutine;

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
            if (_bufferAttackAnimationRoutine != null) StopCoroutine(_bufferAttackAnimationRoutine);
            _bufferAttackAnimationRoutine = StartCoroutine(BufferAttackAnimation());
        }

        public void PlayerOutOfSight()
        {
            StopCoroutine(_bufferAttackAnimationRoutine);
        }

        IEnumerator BufferAttackAnimation()
        {
            while (true)
            {
                _animator.SetTrigger("SwordAttack");
                yield return new WaitForSeconds(WeaponCooldown);
            }
        }
    }
}