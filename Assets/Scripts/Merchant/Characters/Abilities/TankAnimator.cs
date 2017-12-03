using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    public class TankAnimator : CharacterAbility
    {
        private Animator animator;
		private TankShoot tankShoot;

        private void Start()
        {
            this.animator = this.GetComponentInChildren<Animator>();
			this.tankShoot = this.GetComponent<TankShoot>();
        }

        private void Update()
        {
            bool isMoving = this.character.movement.Direction != Vector3.zero;
            bool isFiring = this.tankShoot.isFiring;

            this.animator.SetBool("IsMoving", isMoving);
            this.animator.SetBool("IsFiring", isFiring);
        }
    }
}
