using UnityEngine;

namespace General
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private Vector3 offset;
        private Vector3 _desiredPosition;
        private Transform target;

        private void Awake()
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        private void LateUpdate()
        {
            if (target != null) _desiredPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, _desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothPosition;
        }
    }
}