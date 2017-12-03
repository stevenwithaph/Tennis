using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    public class CharacterHealth : CharacterAbility
    {
        public int health = 0;

        private int maxHealth = 10;

        private float invulnerabilityTimer = 2.0f;
        private bool isInvulnerable = false;

        public void TakeDamge(int damage)
        {
            if (this.isInvulnerable)
            {
                return;
            }

            this.health -= damage;

            if (this.health <= 0)
            {
                this.health = 0;
            }
            else
            {
                this.StartCoroutine(this.InvulnerabilityTimer());
            }
        }

        private void Start()
        {
            this.health = this.maxHealth;   
        }

        private IEnumerator InvulnerabilityTimer()
        {
            this.isInvulnerable = true;

            yield return new WaitForSeconds(this.invulnerabilityTimer);

            this.isInvulnerable = false;
        }
    }   
}
