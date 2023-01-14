using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace CharacterScripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int startingHealth;

        public UnityEvent OnDied;
        private Animator _animator;

        [ReadOnly] private int _currentHealth;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _currentHealth = startingHealth;
            OnDied.AddListener(() => _animator.SetTrigger("Death"));
        }


        public void ChangeHealth(int amount)
        {
            if (!enabled) return;
            _currentHealth += amount;
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