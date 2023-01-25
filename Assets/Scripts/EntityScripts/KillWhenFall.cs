using UnityEngine;

namespace EntityScripts
{
    [RequireComponent(typeof(Health))]
    public class KillWhenFall : MonoBehaviour
    {
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < -1) _health.InstaKill();
        }
    }
}