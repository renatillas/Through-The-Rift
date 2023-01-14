using CharacterScripts;
using UnityEngine;

namespace AttackScripts
{
    public class CollisionKnockback : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private float delay;
        [SerializeField] private Transform origin;

        private void OnTriggerEnter(Collider other)
        {
            var hitObject = other.gameObject;
            TryKnockbackObject(hitObject);
        }

        private void TryKnockbackObject(GameObject objectToStun)
        {
            if (objectToStun.TryGetComponent(out Knockbackable knockableObject))
            {
                knockableObject.ApplyKnockback(origin.position, force, delay);
            }
            else
            {
                Debug.Log($"{knockableObject} cannot be stunned.");
            }
        }
    }
}