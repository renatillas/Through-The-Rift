using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace EntityScripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class KnockbackableNavAgent : MonoBehaviour, IKnockbackable
    {
        [SerializeField] private float knockbackResistance;

        private CharacterMovement _characterMov;

        private void Awake()
        {
            _characterMov = GetComponent<CharacterMovement>();
        }

        public void Update()
        {
            if (KnockbackCounter <= 0) KnockbackCounter = 0;
            else KnockbackCounter -= Time.deltaTime;
        }

        public float KnockbackCounter { get; private set; }

        public IEnumerator ApplyKnockback(Vector3 origin, float magnitude, float secondsDelay)
        {
            throw new NotImplementedException();
        }
    }
}