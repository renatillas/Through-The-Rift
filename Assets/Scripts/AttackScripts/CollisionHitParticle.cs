using General;
using UnityEngine;

namespace AttackScripts
{
    public class CollisionHitParticle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var hitObject = other.gameObject;
            SpawnHitParticle(hitObject);
        }

        private void SpawnHitParticle(GameObject hitObject)
        {
            if (hitObject.TryGetComponent(out Hittable hittableObject))
            {
                hittableObject.Hit();
            }
        }
    }
}