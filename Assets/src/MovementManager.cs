using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.src
{
    public class MovementManager : MonoBehaviour
    {
        [SerializeField, Range(0, 10)]
        float walkSpeed = 200f;
        [SerializeField]
        float jumpDelay = 1f;
        [SerializeField]
        float jumpForce;

        bool hasJumpDelay;
        Rigidbody rb;
        Animator animator;

        private bool IsGrounded()
        {
            return Physics.CheckSphere(transform.position + Vector3.up * 0.1f, 0.2f);
        }

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            animator.SetFloat("Speed", rb.velocity.magnitude);
        }

        public bool TryMove(Vector3 direction)
        {
            if (IsGrounded())

            {
                Move(direction);
                return true;
            }
            return false;
        }

        void Move(Vector3 direction)
        {
            Vector3 velocity = walkSpeed * direction;
            rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
        }


        public bool TryJump()
        {
            if (IsGrounded() && !hasJumpDelay)
            {
                Jump(jumpForce);
                return true;
            }
            return false;
        }

        void Jump(float jumpForce)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            hasJumpDelay = true;
            animator.SetTrigger("Jump");
            StartCoroutine(YieldJumpDelay());
        }

        IEnumerator YieldJumpDelay()
        {
            yield return new WaitForSeconds(jumpDelay);
            hasJumpDelay = false;
        }
    }
}