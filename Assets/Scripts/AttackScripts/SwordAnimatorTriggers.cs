using UnityEngine;

namespace AttackScripts
{
    public class SwordAnimatorTriggers : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private Collider _swordTriggerCollider;

        private void Awake()
        {
            GameObject sword = GameObject.FindWithTag("Sword");
            _particleSystem = sword.GetComponentInChildren<ParticleSystem>();
            _swordTriggerCollider = sword.GetComponent<Collider>();
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