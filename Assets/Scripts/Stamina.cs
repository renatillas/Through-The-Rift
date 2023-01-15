using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] private float maxStamina;
    [SerializeField] private float regenerationDelay;

    private float _currentStamina;
    private Coroutine _regenerationRoutine;
    private WaitForSeconds _regenerationTick;
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
        _regenerationTick = new WaitForSeconds(0.1f);
    }

    public bool UseStamina(float amount)
    {
        if (_currentStamina - amount >= 0)
        {
            if (_regenerationRoutine != null) StopCoroutine(_regenerationRoutine);
            _currentStamina -= amount;
            _staminaBar.value = _currentStamina;

            _regenerationRoutine = StartCoroutine(RegenerateStamina());
            return true;
        }

        Debug.Log("Not enough stamina.");
        return false;
    }

    public bool HasStamina()
    {
        return _currentStamina >= 0;
    }

    private IEnumerator RegenerateStamina()
    {
        yield return new WaitForSeconds(regenerationDelay);
        while (_currentStamina < maxStamina)
        {
            _currentStamina += maxStamina / 100;
            _staminaBar.value = _currentStamina;
            yield return _regenerationTick;
        }
    }
}