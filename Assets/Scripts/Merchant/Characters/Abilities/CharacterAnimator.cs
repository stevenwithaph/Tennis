using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : CharacterAbility
    {
        private Animator animator;

        private void Start()
        {
            this.animator = this.GetComponent<Animator>();
        }

        private void Update()
        {

            bool isMoving = this.character.movement.Direction != Vector2.zero;
            bool isAttacking = this.character.attack.isAttacking;

            this.animator.SetBool("IsMoving", isMoving);
            this.animator.SetBool("IsAttacking", isAttacking);
        }
    }
}
