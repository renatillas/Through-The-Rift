using UnityEngine;
using UnityEngine.Events;

namespace EntityScripts
{
    public class TriggerPlayerOnRange : MonoBehaviour
    {
        public UnityEvent playerEntersAttackRange;
        public UnityEvent playerExitsAttackRange;

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                playerExitsAttackRange.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerEntersAttackRange.Invoke();
            }
        }
    }
}