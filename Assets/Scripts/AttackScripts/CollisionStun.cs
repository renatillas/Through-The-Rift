using CharacterScripts;
using UnityEngine;

namespace AttackScripts
{
    public class CollisionStun : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var hitObject = other.gameObject;
            TryStunObject(hitObject);
        }

        private void OnTriggerExit(Collider other)
        {
            var hitObject = other.gameObject;
            TryUnstunObject(hitObject);
        }

        private void TryStunObject(GameObject objectToStun)
        {
            if (objectToStun.TryGetComponent(out Stunnable stunnableObject))
            {
                stunnableObject.ApplyStun();
            }
            else
            {
                Debug.Log($"{stunnableObject} cannot be stunned.");
            }
        }

        private void TryUnstunObject(GameObject objectToUnstun)
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