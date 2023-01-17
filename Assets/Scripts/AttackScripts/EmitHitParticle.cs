using General;
using UnityEngine;

namespace AttackScripts
{
    public class EmitHitParticle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var hitObject = other.gameObject;
            HitObject(hitObject);
        }

        private void HitObject(GameObject hitObject)
        {
            if (hitObject.TryGetComponent(out Hittable hittableObject))
            {
                hittableObject.Hit();
            }
            else
                Debug.Log($"{hitObject} cannot be hit.");
        }
    }
}