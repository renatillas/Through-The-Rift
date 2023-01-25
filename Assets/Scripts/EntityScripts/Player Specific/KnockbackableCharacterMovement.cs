using System.Collections;
using UnityEngine;

namespace EntityScripts.Player_Specific
{
    [RequireComponent(typeof(CharacterMovement))]
    public class KnockbackableCharacterMovement : MonoBehaviour, IKnockbackable
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
            KnockbackCounter = secondsDelay;
            Vector3 velocity = magnitude * (transform.position - origin).normalized;
            _characterMov.SetStunned();
            _characterMov.BufferKnockBack(velocity);
            yield return new WaitForSeconds(secondsDelay);
            _characterMov.SetUnstunned();
        }
    }
}