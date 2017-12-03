using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    public class CharacterHealth : CharacterAbility
    {
        public int health = 0;

        public Action OnDeath;

        public int maxHealth = 10;

        private float invulnerabilityTimer = 2.0f;
        private bool isInvulnerable = false;

        private new Renderer renderer;

        protected void Start()
        {
            this.renderer = this.GetComponentInChildren<Renderer>();
            this.health = this.maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (this.isInvulnerable)
            {
                return;
            }
            
            this.health -= damage;

            this.StartCoroutine(this.Flash());

            if (this.health <= 0)
            {
                this.health = 0;
                if(this.OnDeath != null)
                {
                    this.OnDeath();
                }
            }
            else
            {
                this.StartCoroutine(this.InvulnerabilityTimer());
            }
        }

        private IEnumerator InvulnerabilityTimer()
        {
            this.isInvulnerable = true;

            yield return new WaitForSeconds(this.invulnerabilityTimer);

            this.isInvulnerable = false;
        }

        protected IEnumerator Flash()
        {
            this.renderer.material.SetFloat("_FlashAmount", 1);

            yield return new WaitForSeconds(0.1f);

            this.renderer.material.SetFloat("_FlashAmount", 0);
        }
    }   
}
