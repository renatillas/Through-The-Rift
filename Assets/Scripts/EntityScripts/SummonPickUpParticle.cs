using UnityEngine;

namespace EntityScripts
{
    public class SummonPickUpParticle : MonoBehaviour
    {
        [SerializeField] private GameObject weapon;
        [SerializeField] private GameObject particle;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                weapon.SetActive(true);
                Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}