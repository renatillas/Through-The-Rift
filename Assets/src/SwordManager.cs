using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.src
{
    public class SwordManager : MonoBehaviour
    {
        [SerializeField]
        private float weaponDelay;
        [SerializeField]
        Animator animator;

        float internalTimer;
        Collider swordCollider;

        private void Awake()
        {
            swordCollider = GetComponent<Collider>();
        }

        private void Start()
        {
            internalTimer = 0;
        }

        private void Update()
        {
            internalTimer -= Time.deltaTime;
            if (internalTimer < 0f)
            {
                StartAttack();
            }
        }

        private void StartAttack()
        {
            internalTimer = weaponDelay;
            swordCollider.enabled = true;
            animator.SetTrigger("SwordAttack");
        }

        public void EndAttack()
        {
            swordCollider.enabled = false;
        }

    }
}