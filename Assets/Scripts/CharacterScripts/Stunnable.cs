using UnityEngine;

namespace CharacterScripts
{
    public class Stunnable : MonoBehaviour
    {
        private RigidbodyConstraints _cachedConstraints;
        private bool _permanentlyStunend;

        private Rigidbody _rb;
        private bool _stun;
        private float _stunAmountAcummulated;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _stun = false;
        }

        private void Update()
        {
            if (_stunAmountAcummulated > 0) _stunAmountAcummulated -= Time.deltaTime;
            if (_stunAmountAcummulated <= 0 && _stun && !_permanentlyStunend) UnapplyStun();
        }

        public void ApplyStun(float stunSeconds)
        {
            _stun = true;
            _cachedConstraints = _rb.constraints;
            _rb.constraints = RigidbodyConstraints.FreezeRotation;
            _stunAmountAcummulated += stunSeconds;
        }

        public void ApplyInfiniteStun()
        {
            _permanentlyStunend = true;
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