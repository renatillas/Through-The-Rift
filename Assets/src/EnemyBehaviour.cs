using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.src
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField]
        Transform playerLocation;

        float playerHeight;
        MovementManager movementManager;

        private void Awake()
        {
            movementManager = GetComponent<MovementManager>();
        }

        private void Update()
        {
            playerHeight = transform.position.y;
        }

        private void FixedUpdate()
        {
            movementManager.TryMove(GetMoveDirection());
            RotateFacingPlayer();
        }

        private void RotateFacingPlayer()
        {
            transform.LookAt(new Vector3(playerLocation.position.x, playerHeight, playerLocation.position.z));
        }

        private void Attack()
        {
            Debug.Log("Enemy attacked player!");
        }

        void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                Attack();
        }

        Vector3 GetMoveDirection()
        {
            return (playerLocation.position - transform.position).normalized;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Weapon"))
            {
                print("Fui atacado!");
            }
        }
    }
}