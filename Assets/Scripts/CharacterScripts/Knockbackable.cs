using UnityEngine;

namespace CharacterScripts
{
    public class Knockbackable : MonoBehaviour
    {
        [SerializeField] private float knockbackResistance;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void ApplyKnockback(Vector3 origin, float magnitude)
        {
            _rb.velocity = Vector3.zero;
            Vector3 direction = transform.position - origin;
            _rb.AddForce(
                direction * magnitude * Time.fixedDeltaTime,
                ForceMode.Impulse);
        }
    }
}