using UnityEngine;

namespace General
{
    public class LookAtCameraUI : MonoBehaviour
    {
        private void FixedUpdate()
        {
            transform.LookAt(transform.position + Camera.main.transform.forward);
        }
    }
}