using System.Collections;
using UnityEngine;

namespace AttackScripts
{
    public class PlayerSwordAttack : MonoBehaviour, IWeaponAttack
    {
        // TODO: Mover stats del arma a un ScriptableObject.
        [SerializeField] private float delay;

        private Animator _animator;

        private void Awake()
        {
            _animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        }

        private void Start()
        {
            StartCoroutine(BufferAnimationAttack());
            StartCoroutine(UpdateAnimationSpeedPeriodically());
        }

        public float WeaponCooldown
        {
            get => delay;
            set => delay = value;
        }

        private IEnumerator BufferAnimationAttack()
        {
            while (true)
            {
                _animator.SetTrigger("SwordAttack");
                yield return new WaitForSeconds(delay);
            }
        }

        private IEnumerator UpdateAnimationSpeedPeriodically()
        {
            var lastAnimationSpeed = 0f;
            WaitForSeconds yieldOneSecond = new WaitForSeconds(1f);
            while (true)
            {
                var animationSpeed = 1 / delay;
                if (animationSpeed.Equals(lastAnimationSpeed)) yield return yieldOneSecond;
                lastAnimationSpeed = animationSpeed;
                _animator.SetFloat("SwordSpeed", animationSpeed);
                yield return yieldOneSecond;
            }
        }
    }
}