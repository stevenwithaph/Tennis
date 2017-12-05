using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : CharacterAbility
    {
        public Vector3 Direction
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
        public bool canMove = true;

        private bool isDashing = false;

        private Vector3 direction;
        private Vector3 dashDirection;
        private CharacterController characterController;

        // Use this for initialization
        private void Start()
        {
            this.characterController = this.GetComponent<CharacterController>();
        }

        protected void OnEnable()
        {
            this.canMove = true;
        }

        private void Update()
        {
            this.characterController.Move(
                this.direction * this.movementSpeed * Time.deltaTime
            );

            if(this.isDashing)
            {
                this.characterController.Move(
                    this.dashDirection * this.dashSpeed * Time.deltaTime
                );
            }

            Vector3 position = this.character.transform.position;
            position.y = 0;
            this.character.transform.position = position;
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

        public void Dash(Vector3 direction)
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
