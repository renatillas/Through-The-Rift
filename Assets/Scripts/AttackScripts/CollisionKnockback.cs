using EntityScripts;
using UnityEngine;

namespace AttackScripts
{
    public class CollisionKnockback : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private float knockTime;
        [SerializeField] private Transform origin;

        private void OnTriggerEnter(Collider other)
        {
            var hitObject = other.gameObject;
            TryKnockbackObject(hitObject);
        }

        private void TryKnockbackObject(GameObject objectToStun)
        {
            if (objectToStun.TryGetComponent(out IKnockbackable knockableObject))
            {
                StartCoroutine(knockableObject.ApplyKnockback(origin.position, force, knockTime));
            }
            else
            {
                Debug.Log($"{knockableObject} cannot be knocked back.");
            }
        }
    }
}