using System.Collections.Generic;
using EntityScripts;
using UnityEngine;

namespace AttackScripts
{
    public class CollisionCachedDamage : MonoBehaviour
    {
        [SerializeField, Range(1, 10)] private int damage;
        [SerializeField, Range(0, 1)] private float secondsBetweenDamage;

        private HashSet<GameObject> _entitiesAttacked;

        private float _timer;

        private void Start()
        {
            _entitiesAttacked = new HashSet<GameObject>();
            _timer = secondsBetweenDamage;
        }

        private void Update()
        {
            if (_timer >= 0) _timer -= Time.deltaTime;
            if (_timer <= 0 && _entitiesAttacked.Count != 0) _entitiesAttacked.Clear();
            if (_timer <= 0) _timer = secondsBetweenDamage;
        }

        private void OnTriggerEnter(Collider other)
        {
            var hitObject = other.gameObject;
            if (_entitiesAttacked.Contains(hitObject)) return;
            _entitiesAttacked.Add(hitObject);
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