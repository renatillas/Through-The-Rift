using System.Linq;
using UnityEngine;

namespace AttackScripts
{
    public class AnimatorSwordTriggers : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private Collider _swordTriggerCollider;

        private void Awake()
        {
            _particleSystem = GetComponentInChildren<ParticleSystem>();
            _swordTriggerCollider = GetComponentsInChildren<BoxCollider>()
                .First(boxCollider => boxCollider.CompareTag("Sword"));
        }

        public void OnAttackStartWind()
        {
            _swordTriggerCollider.enabled = true;
            _particleSystem.Play();
        }

        public void OnAttackEndWind()
        {
            _swordTriggerCollider.enabled = false;
            _particleSystem.Stop();
        }
    }
}