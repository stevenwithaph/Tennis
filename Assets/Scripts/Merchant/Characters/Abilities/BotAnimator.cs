using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    public class BotAnimator : CharacterAbility
    {
        private Animator animator;
		private BotFire botFire;

        protected void Start()
        {
            this.animator = this.GetComponentInChildren<Animator>();
            this.botFire = this.GetComponent<BotFire>();
        }

        protected void Update()
        {
            bool isMoving = this.character.movement.Direction != Vector3.zero;
            bool isSettingUp = this.botFire.isSettingUp;
            bool isFiring = this.botFire.isFiring;
            bool isChargedShot = this.botFire.isChargedShot;

            this.animator.SetBool("IsMoving", isMoving);
            this.animator.SetBool("IsSettingUp", isSettingUp);
            this.animator.SetBool("IsFiring", isFiring);
            this.animator.SetBool("IsChargedShot", isChargedShot);
        }
    }
}
