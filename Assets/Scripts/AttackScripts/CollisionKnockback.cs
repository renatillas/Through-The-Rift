using CharacterScripts;
using UnityEngine;

namespace AttackScripts
{
    public class CollisionKnockback : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float knockbackForce;

        private void OnTriggerEnter(Collider other)
        {
            var hitObject = other.gameObject;
            TryKnockbackObject(hitObject);
        }

        private void TryKnockbackObject(GameObject objectToStun)
        {
            if (objectToStun.TryGetComponent(out Knockbackable knockableObject))
            {
                Vector3 origin = transform.position;
                knockableObject.ApplyKnockback(origin, knockbackForce);
            }
            else
            {
                Debug.Log($"{knockableObject} cannot be stunned.");
            }
        }
    }
}