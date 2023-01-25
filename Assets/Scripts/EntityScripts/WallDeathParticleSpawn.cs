using UnityEngine;

namespace EntityScripts
{
    public class WallDeathParticleSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject deathParticle;

        public void ShowBrokenParticle()
        {
            Instantiate(deathParticle, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(this.gameObject);
        }
    }
}