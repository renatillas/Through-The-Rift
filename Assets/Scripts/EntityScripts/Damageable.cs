using UnityEngine;
using UnityEngine.Events;

namespace EntityScripts
{
    [RequireComponent(typeof(Health))]
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private UnityEvent<int> onDamaged;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        public void DealDamage(int damageAmount)
        {
            Debug.Log($"{gameObject} has been dealt damage.");
            _health.ChangeHealth(-damageAmount);
            onDamaged.Invoke(damageAmount);
        }
    }
}