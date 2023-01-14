using System.Collections;
using UnityEngine;

namespace CharacterScripts
{
    public class Knockbackable : MonoBehaviour
    {
        [SerializeField] private float knockbackResistance;
        private bool _knockedBack;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void ApplyKnockback(Vector3 origin, float magnitude, float secondsDelay)
        {
            if (_knockedBack)
            {
                Debug.Log($"{gameObject} is already being knocked back.");
                return;
            }

            _knockedBack = true;
            Debug.Log($"{gameObject} is knocked back.");
            _rb.velocity = Vector3.zero;
            Vector3 direction = _rb.centerOfMass - origin;
            _rb.AddForce(
                direction * magnitude,
                ForceMode.Impulse);
            StartCoroutine(ResetKnockback(secondsDelay));
        }

        private IEnumerator ResetKnockback(float secondsDelay)
        {
            yield return new WaitForSeconds(secondsDelay);
            _knockedBack = false;
        }
    }
}