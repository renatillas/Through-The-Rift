using CharacterScripts;
using UnityEngine;

namespace AttackScripts
{
    public class CollisionStun : MonoBehaviour
    {
        [SerializeField, Range(0, 3)] private float stunSeconds;

        private void OnTriggerEnter(Collider other)
        {
            var hitObject = other.gameObject;
            StunObject(hitObject);
        }

        private void StunObject(GameObject objectToStun)
        {
            if (objectToStun.TryGetComponent(out Stunnable stunnableObject))
            {
                stunnableObject.ApplyStun(stunSeconds);
            }
            else
            {
                Debug.Log($"{stunnableObject} cannot be stunned.");
            }
        }

        private void UnstunObject(GameObject objectToUnstun)
        {
            if (objectToUnstun.TryGetComponent(out Stunnable stunnableObject))
            {
                stunnableObject.UnapplyStun();
            }
            else
            {
                Debug.Log($"{stunnableObject} cannot be stunned.");
            }
        }
    }
}