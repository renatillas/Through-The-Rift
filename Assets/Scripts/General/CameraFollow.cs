using UnityEngine;

namespace General
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float smoothSpeed = 0.125f;
        private Vector3 _desiredPosition;
        private Vector3 _offset;
        private Transform _target;

        private void Awake()
        {
            _target = GameObject.FindWithTag("Player").transform;
        }

        private void Start()
        {
            _offset = transform.position;
        }

        private void LateUpdate()
        {
            if (_target != null) _desiredPosition = _target.position + _offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, _desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothPosition;
        }
    }
}