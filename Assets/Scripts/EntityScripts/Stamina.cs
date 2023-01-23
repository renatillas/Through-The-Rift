using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace EntityScripts
{
    public class Stamina : MonoBehaviour
    {
        [SerializeField] private float maxStamina;
        [SerializeField] private float recoveryDelay;
        [SerializeField] private float regenerationStaminaPerSecond;
        [SerializeField] private float regenerationDelay;

        private float _currentStamina;
        private Coroutine _regenerationRoutine;
        private Slider _staminaBar;

        private void Awake()
        {
            _staminaBar = gameObject.GetComponentsInChildren<Slider>().First(slider => slider.CompareTag("StaminaBar"));
        }

        private void Start()
        {
            _currentStamina = maxStamina;
            _staminaBar.maxValue = maxStamina;
            _staminaBar.value = maxStamina;
        }

        public bool UseStamina(float amountStamina)
        {
            if (_currentStamina - amountStamina < 0) return false;
            if (_regenerationRoutine != null) StopCoroutine(_regenerationRoutine);
            _currentStamina -= amountStamina;
            _staminaBar.value = _currentStamina;
            _regenerationRoutine = StartCoroutine(RegenerateStamina());
            return true;
        }

        private IEnumerator RegenerateStamina()
        {
            yield return new WaitForSeconds(recoveryDelay);
            while (_currentStamina < maxStamina)
            {
                float staminaGainedPerTick = regenerationStaminaPerSecond * regenerationDelay;
                _currentStamina += staminaGainedPerTick;
                _staminaBar.value = _currentStamina;
                yield return new WaitForSeconds(regenerationDelay);
            }

            _currentStamina = maxStamina;
        }

        public bool HasStamina()
        {
            return _currentStamina >= 0;
        }
    }
}