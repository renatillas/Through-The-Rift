using UnityEngine;
using UnityEngine.Events;

namespace EntityScripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int startingHealth;

        public UnityEvent onDied;
        public UnityEvent<int> onHealthChanged;
        private Animator _animator;

        private int _currentHealth;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _currentHealth = startingHealth;
            onDied.AddListener(() => _animator.SetTrigger("Death"));
        }


        public void ChangeHealth(int amount)
        {
            if (!enabled) return;

            _currentHealth += amount;
            onHealthChanged?.Invoke(amount);
            if (IsDead())
            {
                Die();
            }
        }

        public int GetStartingHealth()
        {
            return startingHealth;
        }

        private void Die()
        {
            onDied?.Invoke();
        }

        public void InstaKill()
        {
            if (!IsDead())
                ChangeHealth(-GetStartingHealth() * 1000);
        }

        public bool IsDead()
        {
            return _currentHealth <= 0;
        }
    }
}