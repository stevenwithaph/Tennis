using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    public class CharacterAnimator : CharacterAbility
    {
        private Animator animator;

        private void Start()
        {
            this.animator = this.GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            bool isMoving = this.character.movement.Direction != Vector3.zero;
            bool isAttacking = this.character.attack.isAttacking;

            this.animator.SetBool("IsMoving", isMoving);
            this.animator.SetBool("IsAttacking", isAttacking);
        }
    }
}
