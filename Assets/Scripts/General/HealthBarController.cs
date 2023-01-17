using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace EntityScripts
{
    [RequireComponent(typeof(Health))]
    public class HealthBarController : MonoBehaviour
    {
        private Health _health;
        private Slider _healthBar;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _healthBar = gameObject.GetComponentsInChildren<Slider>().First(slider => slider.CompareTag("HealthBar"));
        }

        private void Start()
        {
            _healthBar.maxValue = _health.GetStartingHealth();
            _healthBar.value = _health.GetStartingHealth();
            _health.onDied.AddListener(() => _healthBar.GetComponentInChildren<Image>().color = Color.grey);
            _health.onHealthChanged.AddListener((amount) => _healthBar.value += amount);
        }
    }
}