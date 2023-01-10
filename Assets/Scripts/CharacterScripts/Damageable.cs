using UnityEngine;

namespace CharacterScripts
{
    [RequireComponent(typeof(Health))]
    public class Damageable : MonoBehaviour
    {
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        public void DealDamage(int damageAmount)
        {
            _health.ChangeHealth(damageAmount);
        }
    }
}