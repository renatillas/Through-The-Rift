using EntityScripts;
using UnityEngine;

namespace AttackScripts
{
    [RequireComponent(typeof(Collider), typeof(IWeaponAttack))]
    public class CollisionDamage : MonoBehaviour
    {
        [SerializeField, Range(1, 10)] private int damage;

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