using UnityEngine;
using UnityEngine.Events;

namespace EntityScripts
{
    public class TriggerPlayerOnRange : MonoBehaviour
    {
        public UnityEvent playerOnRange;
        public UnityEvent playerOutOfRange;

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                playerOutOfRange.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player is on range");
                playerOnRange.Invoke();
            }
        }
    }
}