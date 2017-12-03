using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    [RequireComponent(typeof(CharacterController2D))]
    public class CharacterMovement : CharacterAbility
    {
        public Vector2 Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                if (!this.canMove)
                {
                    this.direction = Vector2.zero;
                }
                else
                {
                    if (value.magnitude > 1.0f)
                    {
                        value.Normalize();
                    }

                    this.direction = value;
                }
            }
        }

        public float dashSpeed = 20.0f;
        public float dashTime = 0.25f;

        public float movementSpeed = 5.0f;
        private bool canMove = true;
        private bool isDashing = false;

        private Vector2 direction;
        private Vector2 dashDirection;
        private CharacterController2D characterController;

        // Use this for initialization
        private void Start()
        {
            this.characterController = this.GetComponent<CharacterController2D>();

            Rigidbody2D body = this.GetComponent<Rigidbody2D>();

            body.gravityScale = 0;
            body.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        private void Update()
        {
            this.characterController.move(
                this.direction * this.movementSpeed * Time.deltaTime
            );

            if(this.isDashing)
            {
                this.characterController.move(
                    this.dashDirection * this.dashSpeed * Time.deltaTime
                );
            }
        }

        public void PreventMovement()
        {
            this.canMove = false;
            this.direction = Vector2.zero;
        }

        public void EnableMovement()
        {
            this.canMove = true;
        }

        public void Dash(Vector2 direction)
        {
            this.dashDirection = direction;
            this.StartCoroutine(this.DashCoroutine());
        }

        private IEnumerator DashCoroutine()
        {
            this.isDashing = true;
            this.canMove = false;
            yield return new WaitForSeconds(this.dashTime);

            this.isDashing = false;
            this.canMove = true;
        }
    }
}
