using System.Collections;
using UnityEngine;

namespace EntityScripts
{
    [RequireComponent(typeof(CharacterMovement))]
    public class Knockbackable : MonoBehaviour
    {
        [SerializeField] private float knockbackResistance;

        private CharacterMovement _characterMov;
        private float _knockbackCounter;

        private void Awake()
        {
            _characterMov = GetComponent<CharacterMovement>();
        }

        public void Update()
        {
            if (_knockbackCounter <= 0) _knockbackCounter = 0;
            else _knockbackCounter -= Time.deltaTime;
        }

        public IEnumerator ApplyKnockback(Vector3 origin, float magnitude, float secondsDelay)
        {
            _knockbackCounter = secondsDelay;
            Vector3 velocity = magnitude * (transform.position - origin).normalized;
            _characterMov.SetStunned();
            _characterMov.BufferKnockBack(velocity);
            yield return new WaitForSeconds(secondsDelay);
            _characterMov.SetUnstunned();
        }
    }
}