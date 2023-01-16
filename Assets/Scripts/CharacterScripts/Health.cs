using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CharacterScripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int startingHealth;

        public UnityEvent OnDied;
        private Animator _animator;

        private int _currentHealth;
        private Slider _healthBar;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _healthBar = gameObject.GetComponentsInChildren<Slider>().First(slider => slider.CompareTag("HealthBar"));
        }

        private void Start()
        {
            _currentHealth = startingHealth;
            _healthBar.maxValue = startingHealth;
            _healthBar.value = startingHealth;
            OnDied.AddListener(() => _animator.SetTrigger("Death"));
            OnDied.AddListener(() => _healthBar.GetComponentInChildren<Image>().color = Color.grey);
        }


        public void ChangeHealth(int amount)
        {
            if (!enabled) return;

            _healthBar.value += amount;
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