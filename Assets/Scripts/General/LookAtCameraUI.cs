using UnityEngine;

namespace General
{
    public class LookAtCameraUI : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            transform.LookAt(transform.position + _camera.transform.forward);
        }
    }
}