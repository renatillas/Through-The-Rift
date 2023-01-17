using UnityEngine;
using UnityEngine.Events;

namespace EntityScripts
{
    public class TriggerPlayerOnRange : MonoBehaviour
    {
        public UnityEvent playerOnRange;
        public UnityEvent playerOutOfRange;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                playerOnRange.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                playerOutOfRange.Invoke();
        }
    }
}