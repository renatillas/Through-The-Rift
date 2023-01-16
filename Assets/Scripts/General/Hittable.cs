using UnityEngine;

namespace General
{
    public class Hittable : MonoBehaviour
    {
        [SerializeField] private GameObject hitParticle;

        public void Hit()
        {
            Instantiate(hitParticle, transform.position, Quaternion.identity);
        }
    }
}