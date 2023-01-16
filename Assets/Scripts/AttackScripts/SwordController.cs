using System.Collections;
using UnityEngine;

namespace AttackScripts
{
    [RequireComponent(typeof(CollisionCachedDamage))]
    public class SwordController : MonoBehaviour
    {
        [SerializeField] private float delay;
        private Animator _animator;
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponentInChildren<ParticleSystem>();
            _animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        }

        private void Start()
        {
            _particleSystem.Stop();
            StartCoroutine(BufferAnimationAttack());
            StartCoroutine(UpdateAnimationSpeedPeriodically());
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
            while (true)
            {
                var animationSpeed = 1 / delay;
                _animator.SetFloat("SwordSpeed", animationSpeed);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}