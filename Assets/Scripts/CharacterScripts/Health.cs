using System;
using UnityEngine;

namespace CharacterScripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int startingHealth;
        private Animator _animator;
        private int _currentHealth;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _currentHealth = startingHealth;
            OnDied += () => _animator.SetTrigger("Death");
        }

        public event Action OnDied;

        public void ChangeHealth(int amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            OnDied?.Invoke();
        }
    }
}