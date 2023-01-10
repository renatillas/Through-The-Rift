using UnityEngine;

namespace CharacterScripts
{
    public class Stunnable : MonoBehaviour
    {
        private RigidbodyConstraints _cachedConstraints;

        private Rigidbody _rb;
        private bool _stun;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _stun = false;
        }

        public void ApplyStun()
        {
            _stun = true;
            _cachedConstraints = _rb.constraints;
            _rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        public void UnapplyStun()
        {
            _stun = false;
            _rb.constraints = _cachedConstraints;
        }

        public bool IsStunned()
        {
            return _stun;
        }
    }
}