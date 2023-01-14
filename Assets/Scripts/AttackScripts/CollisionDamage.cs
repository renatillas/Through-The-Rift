using CharacterScripts;
using UnityEngine;

namespace AttackScripts
{
    public class CollisionDamage : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] protected int damage;

        private void OnTriggerEnter(Collider other)
        {
            var hitObject = other.gameObject;
            DamageObject(hitObject);
        }

        private void DamageObject(GameObject objectToDamage)
        {
            if (objectToDamage.TryGetComponent(out Damageable damageableObject))
            {
                damageableObject.DealDamage(damage);
            }
            else
            {
                Debug.Log($"{objectToDamage} cannot be damaged.");
            }
        }
    }
}