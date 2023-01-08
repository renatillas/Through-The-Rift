using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.src
{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField]
        Transform body;
        [SerializeField]
        float rotationSpeed;

        MovementManager movementManager;

        private void Awake()
        {
            movementManager = GetComponent<MovementManager>();
        }

        private void Update()
        {
            RotateBody();
        }

        void FixedUpdate()
        {
            if (Input.GetAxis("Jump") > 0)
                movementManager.TryJump();

            if (GetMoveDirection().sqrMagnitude > 0)
                movementManager.TryMove(GetMoveDirection());
        }

        Vector3 GetMoveDirection()
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }

        void RotateBody()
        {
            Vector3 direction = GetMoveDirection();
            if (direction.sqrMagnitude >= 0.1)
                body.rotation = Quaternion.Slerp(body.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }
    }
}